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
                        cmd.Parameters.AddWithValue("@precio", decimal.Parse(prod.precio));

                        cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                throw;
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
                        prod.precio = row["precio"].ToString();
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
        //Edit
        //[HttpGet] 
        public IActionResult Edit(int id)
        {
            Producto producto = null;
            _connection.Open();
            try
            {
                using (var cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT id_producto, nombre, stock_cantidad, categoria, precio  FROM [Tienda].[dbo].[Producto] WHERE id_producto = @id;";
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int _id = (int)reader[0];
                        string nombre = reader[1].ToString();
                        int stock = (int)reader[2];
                        int categoria = (int)reader[3];
                        string precio = reader[4].ToString();

                        producto = new Producto(_id, nombre, stock, categoria, precio);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { _connection.Close(); }
            return View(producto);
        }

        //Para editar en registro en base de datos 
        [HttpPost]
        public IActionResult EditByID(Producto prod)
        {
            prod.precio = prod.precio.ToString().Replace(".", ",");
            try
            {
                _connection.Open();
                ViewData["ConnectionStatus"] = "Connection successful!";
                using (var cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE [Tienda].[dbo].[Producto] SET stock_cantidad = @stock , categoria = @categoria, precio = @precio, nombre = @nombre WHERE id_producto = @id;";
                    cmd.Parameters.AddWithValue("@stock", prod.stock_cantidad);
                    cmd.Parameters.AddWithValue("@categoria", prod.categoria);
                    cmd.Parameters.AddWithValue("@precio", decimal.Parse(prod.precio));
                    cmd.Parameters.AddWithValue("@nombre", prod.nombre);
                    cmd.Parameters.AddWithValue("@id", prod.id_producto);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                ViewData["ConnectionStatus"] = $"Connection failed: {ex.Message}";
            }
            finally { _connection.Close();}


            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }


        //Encontrar un producto por nombre

        public IActionResult DetailsByName(string nombre) {
            return View(returnIDProductosByName(nombre));
        }

        public List<Producto> returnIDProductosByName(string nombre)
        {
            List<Producto> productos = new List<Producto> ();
            _connection.Open(); 
            try {
                using (var cmd = _connection.CreateCommand()) {
                    cmd.CommandText = "SELECT id_producto, nombre, stock_cantidad, categoria, precio FROM [Tienda].[dbo].[Producto] WHERE nombre = @nombre;";
                    cmd.Parameters.AddWithValue("@nombre", nombre);

                    SqlDataReader reader = cmd.ExecuteReader();

                        bool salida = false;
                        while (true)
                        {
                            if (reader.Read() != salida)
                            {

                                int _id = (int)reader[0];
                                string _nombre = reader[1].ToString();
                                int stock = (int)reader[2];
                                int categoria = (int)reader[3];
                                string precio = reader[4].ToString();
                                productos.Add(new Producto(_id, _nombre, stock, categoria, precio));
                            }
                            else { 
                                salida = true;
                                break;
                            }
                        }   
                    

                }
            }catch (Exception e){
                throw;
            }
            return productos;
        }

        //Details
        //para mostrar detalles del producto elegido desde desde ver productos 
        public IActionResult Details(int id ) {

            Producto producto = null;
            _connection.Open();
            try
            {
                using (var cmd = _connection.CreateCommand()) {
                    cmd.CommandText = "SELECT id_producto, nombre, stock_cantidad, categoria, precio FROM [Tienda].[dbo].[Producto] WHERE id_producto = @id;";
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int _id = (int)reader[0];
                        string nombre = reader[1].ToString();
                        int stock = (int)reader[2];
                        int categoria = (int)reader[3];
                        string precio = reader[4].ToString();

                        producto = new Producto(_id, nombre, stock, categoria, precio);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }    
            
            return View(producto); 
        }   

        //eliminar producto

        [HttpGet] 
        public IActionResult Delete(int id) //rellena la vista Delete con los datos del producto que se selecciono para eliminar desde la vista.
        {
            Producto producto = null;
            _connection.Open();
            try
            {
                using (var cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT id_producto, nombre, stock_cantidad, categoria, precio FROM [Tienda].[dbo].[Producto] WHERE id_producto = @id;";
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int _id = (int) reader[0];
                        string nombre = reader[1].ToString();
                        int stock = (int) reader[2];
                        int categoria = (int) reader[3];
                        string precio = reader[4].ToString();

                        producto = new Producto(_id, nombre, stock, categoria, precio);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }finally { _connection.Close(); }
            return View(producto);
        }

        //Delete by id
        [HttpPost]
        public IActionResult DeleteOnDB(Producto producto)
        {
            Producto _producto = new Producto();
            try
            {
                _connection.Open();
                ViewData["ConnectionStatus"] = "Connection successful!";

                _producto.id_producto = producto.id_producto;

                using (var cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM [Tienda].[dbo].[Producto] WHERE id_producto = @id;";
                    cmd.Parameters.AddWithValue("@id", _producto.id_producto);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally { _connection.Close(); }

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
    }
}
