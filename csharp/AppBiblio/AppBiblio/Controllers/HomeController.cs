using AppBiblio.Models;
using BibliotecaAppWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace AppBiblio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Contexto _contexto;
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(ILogger<HomeController> logger, Contexto contexto, IHostingEnvironment hostingEviroment)
        {
            _logger = logger;
            _contexto = contexto;
            _hostingEnvironment = hostingEviroment; 
        }


        //cargar datos de JSON a mi base de datos (simulamos una API)
        public async Task<IActionResult> UploadLibrosFromJSON()
        {
            try
            {
                // Construct relative path
                string filePath = Path.Combine(_hostingEnvironment.ContentRootPath, "biblioAppiV1.json");

                // Read JSON file
                string jsonString = await File.ReadAllTextAsync(filePath);

                // Process and upload data (explained in next steps)

                return RedirectToAction(nameof(Index)); // Redirect to a success page or view
            }
            catch (Exception ex)
            {
                // Handle exceptions (log, display user-friendly message)
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }


        public IActionResult Index()
        {
            var libros = _contexto.misLibros.ToList();
            return View(libros);
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
