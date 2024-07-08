using Microsoft.AspNetCore.Routing.Constraints;

namespace Inmobiliaria.Models
{
    public interface iInmueble
    {
        public double? calcularRebaja();

        public double? calcularPrecio(); 
    }
}
