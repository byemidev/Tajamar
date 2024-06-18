using almacenApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace almacenApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        
        //aqui llamar al dbcontext
       
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost] //no funciona necesito entender como hacer post sin bdcontexto 
        public IActionResult CreateProducto(Producto prod)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open(); // Explicitly open the connection for clarity

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO [Tienda].[dbo].[Product] (nombre, stock_cantidad, categoria, precio) VALUES (@nombre, @stockCantidad, @categoria, @precio)";

                        // Use parameterized queries to prevent SQL injection vulnerabilities
                        command.Parameters.AddWithValue("@nombre", prod.nombre);
                        command.Parameters.AddWithValue("@stockCantidad", prod.stock_cantidad);
                        command.Parameters.AddWithValue("@categoria", prod.categoria);
                        command.Parameters.AddWithValue("@precio", prod.precio);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                return Error();
            }
            return View(prod);
        }


        List<Producto> _listaProductos = new List<Producto>();
        public IActionResult verProductos() {
            try
            {
                using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"))) 
                {
                    conn.Open();
                    // cargar el menu 

                    string str_query = @"select * from [Tienda].[dbo].[Producto];";

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = new SqlCommand(str_query, conn);
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

                    conn.Close();
                    ViewData["ConnectionStatus"] = "Connection successful!";
                }
            }
            catch (Exception ex)
            {
                ViewData["ConnectionStatus"] = $"Connection failed: {ex.Message}";
            }
            return View(_listaProductos); //mostrar vista home+menu
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
