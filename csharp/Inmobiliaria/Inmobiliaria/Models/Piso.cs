using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models
{
    public class Piso : Inmueble
    {
        [Display(Name = "Planta")]
        public int? planta { get; set; }

        public Piso(string? direccion, int? metros, bool? es_nuevo, double? precio_base, DateOnly? fecha_construccion, int? planta) : 
            base( direccion,  metros,  es_nuevo,  precio_base,  fecha_construccion)
        { 
            this.planta = planta;
        }

        public Piso() { 
            //constructor vacio
        }

        public override double? calcularRebaja()
        {
            double? rebajaTotal = base.calcularRebaja();
             
            if (this.planta >= 3)
            {
                rebajaTotal += base.precio_base * 0.03d;
            }
            return rebajaTotal;
        }
    }
}
