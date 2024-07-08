using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models
{
    public class Local : Inmueble
    {
        [Display(Name = "Nro Ventanas")]
        public int? nro_ventanas { get; set; }
      
        public Local(string? direccion, int? metros, bool? es_nuevo, double? precio_base, DateOnly? fecha_construccion, int? nro_ventanas) :
            base( direccion,  metros,  es_nuevo,  precio_base,  fecha_construccion)
        {
            this.nro_ventanas = nro_ventanas;
        }

        public Local() { 
            //constructor vacio
        }

        public override double? calcularRebaja()
        {
            double? rebajaTotal = base.calcularRebaja(); 

            if (base.metros >= 50) { //si tiene mas de 50m 
                rebajaTotal += base.precio_base * 0.01d; 
            }

            if (this.nro_ventanas <= 1) { //si tiene 1 o  niguna 
                rebajaTotal -= base.precio_base * 0.02d;
            } else if (this.nro_ventanas > 4) { //si tiene mas de 4
                rebajaTotal += base.precio_base * 0.02d;
            }

            return rebajaTotal;
        }
    }
}
