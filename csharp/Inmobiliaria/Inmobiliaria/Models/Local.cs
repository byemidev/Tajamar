using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models
{
    public class Local : Inmueble
    {
        [Display(Name = "Nro Ventanas")]
        public int _nroVentanas { get; set; }
      

        public override double calcularRebaja()
        {
            double rebajaTotal = base.calcularRebaja(); 

            if (base._metros >= 50) { //si tiene mas de 50m 
                rebajaTotal += base._base * 0.01d; 
            }

            if (this._nroVentanas <= 1) { //si tiene 1 o  niguna 
                rebajaTotal -= base._base * 0.02d;
            } else if (this._nroVentanas > 4) { //si tiene mas de 4
                rebajaTotal += base._base * 0.02d;
            }

            return rebajaTotal;
        }
    }
}
