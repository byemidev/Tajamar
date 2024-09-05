using Microsoft.AspNetCore.Mvc;
using System;
using WebAPI.Modelo;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeticionController : ControllerBase
    {
       

        private readonly ILogger<PeticionController> _logger;

        public PeticionController(ILogger<PeticionController> logger)
        {
            _logger = logger;
        }
        private string getColaLlamada(String numero)
        {
            Proceso p = new Proceso();
            
            // Aqui meto el algoritmo
            return p.ConsultarTabla(numero);
        }

        private bool getValidaID(String token)
        {
            bool valida = false;
            if (token== "123")
            {
                valida = true;
            }
            return valida;
        }

        [HttpPost(Name = "GetPeticion")]
        public Respuesta Get(Peticion miPeticion)
        {
            Respuesta resp = new Respuesta();
            // VALIDAMOS EL TOKEN
           if (miPeticion.Auth == "1234ABCD")
            {
                resp.error = 200;
                String numeroCola = this.getColaLlamada(miPeticion.numero); // Aqui hacemos el proceso de buscar la cola de llamada
                return new Respuesta
                {
                    Date = DateOnly.FromDateTime(DateTime.Now), 
                    cola = numeroCola,
                    id = miPeticion.id,
                    error = resp.error
                };
            }
            else { // TOKEN INCORRECTO
                resp.error = 500;
                 return new Respuesta
                {
                    cola = "ERROR",
                    id = miPeticion.id,
                    error = resp.error
                };
            }
            
        }

        
    }
}
