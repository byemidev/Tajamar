using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models
{
    public class Local : Inmueble
    {
        [Display(Name = "Nro Ventanas")]
        public int nro_ventas { get; set; }
      

        public override double calcularRebaja()
        {
            double rebajaTotal = base.calcularRebaja(); 

            if (base.metros >= 50) { //si tiene mas de 50m 
                rebajaTotal += base.precio_base * 0.01d; 
            }

            if (this.nro_ventas <= 1) { //si tiene 1 o  niguna 
                rebajaTotal -= base.precio_base * 0.02d;
            } else if (this.nro_ventas > 4) { //si tiene mas de 4
                rebajaTotal += base.precio_base * 0.02d;
            }

            return rebajaTotal;
        }
    }
}
