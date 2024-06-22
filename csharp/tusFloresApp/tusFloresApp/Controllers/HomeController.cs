using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;
using tusFloresApp.Models;

namespace tusFloresApp.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly GestorConn _gestorConn;

        public HomeController(IConfiguration configuration)
        {
            this._gestorConn = new GestorConn(configuration); 
        }

        public IActionResult Index()
        {
            try
            {
                // Open the connection
                _gestorConn.openConn();
                ViewBag.ConnectionStatus = "Connection opened successfully";

                // You can perform any database operations here
                // Example:
                using (SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM SomeTable", _gestorConn.getConection()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ViewBag.Data = reader[0].ToString();
                        }
                    }
                }

                // Close the connection
                _gestorConn.closeConn();
                ViewBag.ConnectionStatus += " and closed successfully.";
            }
            catch (Exception ex)
            {
                ViewBag.ConnectionStatus = $"Error: {ex.Message}";
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
