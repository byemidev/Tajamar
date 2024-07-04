using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models
{
    public class Piso : Inmueble
    {
        [Display(Name = "Planta")]
        public int _planta { get; set; }
      

        public override double calcularRebaja()
        {
            double rebajaTotal = base.calcularRebaja();
             
            if (this._planta >= 3)
            {
                rebajaTotal += base._base * 0.03d;
            }
            return rebajaTotal;
        }
    }
}
