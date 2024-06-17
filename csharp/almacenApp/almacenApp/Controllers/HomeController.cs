using almacenApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
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
            try
            {
                using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"))) // Get configuration from somewhere, e.g., appsettings.json
                {
                    conn.Open();
                    // cargar el menu 

                    conn.Close();
                    ViewData["ConnectionStatus"] = "Connection successful!";
                }
            }
            catch (Exception ex)
            {
                ViewData["ConnectionStatus"] = $"Connection failed: {ex.Message}";
            }
            return View(); //mostrar vista home+menu
        }

        public ActionResult getMenu() {
            return PartialView("Productos"); //review
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
