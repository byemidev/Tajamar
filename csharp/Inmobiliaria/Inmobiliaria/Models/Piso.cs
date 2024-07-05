using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models
{
    public class Piso : Inmueble
    {
        [Display(Name = "Planta")]
        public int planta { get; set; }
      

        public override double calcularRebaja()
        {
            double rebajaTotal = base.calcularRebaja();
             
            if (this.planta >= 3)
            {
                rebajaTotal += base.precio_base * 0.03d;
            }
            return rebajaTotal;
        }
    }
}
