using Microsoft.AspNetCore.Mvc;
using MVCBiblioteca.Services.Interfaces;

namespace MVCBiblioteca.Controllers
{
    public class BibliotecasController : Controller
    {
        private readonly IBibliotecasAPIService _service;

        public BibliotecasController (IBibliotecasAPIService service) { 
            this._service = service ?? throw new ArgumentNullException(nameof( service ));    
        }
        public async Task<IActionResult> BibliotecasIndex() {
            var libros = await _service.Find();
            return View(libros);
        }
    }
}
