using almacenApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace almacenApp.Controllers
{
    public class ProductoController : Controller
    {
        private readonly SqlConnection _connection; 
        private readonly IConfiguration _configuration; 


        public ProductoController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create() {
            return View();  
        }

        //Insertar Productos
        [HttpPost]
        public IActionResult createProductoOnDB(Producto prod)
        {
            _connection.Open();
            try
            {
                using (var cmd = _connection.CreateCommand())
                {
                        cmd.CommandText = "INSERT INTO [Tienda].[dbo].[Producto] (nombre, stock_cantidad, categoria, precio) VALUES (@nombre, @stockCantidad, @categoria, @precio)";

                        // Use parameterized queries to prevent SQL injection vulnerabilities
                        cmd.Parameters.AddWithValue("@nombre", prod.nombre);
                        cmd.Parameters.AddWithValue("@stockCantidad", prod.stock_cantidad);
                        cmd.Parameters.AddWithValue("@categoria", prod.categoria);
                        cmd.Parameters.AddWithValue("@precio", prod.precio);

                        cmd.ExecuteNonQuery();

                    ViewData["ConnectionStatus"] = "Insertado...";
                }
            }
            catch (Exception ex)
            {
                ViewData["ConnectionStatus"] = $"Connection failed: {ex.Message}";
            }
            finally {
                _connection.Close();
            }
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        //listar productos
        List<Producto> _listaProductos = new List<Producto>();
        public IActionResult List()
        {
            try
            {
                using (_connection)
                {
                    
                    string str_query = @"SELECT * FROM [Tienda].[dbo].[Producto];";

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = new SqlCommand(str_query, _connection);
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        var prod = new Producto();
                        prod.id_producto = int.Parse(row["id_producto"].ToString());
                        prod.stock_cantidad = int.Parse(row["stock_cantidad"].ToString());
                        prod.categoria = int.Parse(row["categoria"].ToString());
                        prod.precio = double.Parse(row["precio"].ToString());
                        prod.nombre = row["nombre"].ToString();

                        _listaProductos.Add(prod);
                    }

                    ViewData["ConnectionStatus"] = "Connection successful!";
                }
            }
            catch (Exception ex)
            {
                ViewData["ConnectionStatus"] = $"Connection failed: {ex.Message}";
            }
            finally {
                _connection.Close();
            }
            return View(_listaProductos); 
        }
        //editar

        [HttpGet]
        public IActionResult Edit(int _id)
        {
            Producto producto = null;
            _connection.Open();
            try
            {
                using (var cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Tienda].[dbo].[Producto] WHERE id_producto = @id;";
                    cmd.Parameters.AddWithValue("@id", _id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    if (reader.Read())
                    {
                        producto = new Producto {
                            id_producto = reader.GetInt32(0),
                            stock_cantidad = reader.GetInt32(1),
                            categoria = reader.GetInt32(2),
                            precio = double.Parse(reader.GetDecimal(3).ToString()),
                            nombre = reader.GetString(4)
                        };
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(producto);
        }

        //Para editar en registro en base de datos 
        [HttpPost]
        public IActionResult EditByID(Producto prod)
        {
            try
            {
                _connection.Open();
                ViewData["ConnectionStatus"] = "Connection successful!";
                using (var cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE [Tienda].[dbo].[Producto] SET stock_cantidad = @stock , categoria = @categoria, precio = @precio, nombre = @nombre WHERE id_producto = @id;";
                    cmd.Parameters.AddWithValue("@stock", prod.stock_cantidad);
                    cmd.Parameters.AddWithValue("@categoria", prod.categoria);
                    cmd.Parameters.AddWithValue("@precio", prod.precio);
                    cmd.Parameters.AddWithValue("@nombre", prod.nombre);
                    cmd.Parameters.AddWithValue("@id", prod.id_producto);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                ViewData["ConnectionStatus"] = $"Connection failed: {ex.Message}";
            }
            finally {
                _connection.Close();
            }


            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

    }
}
