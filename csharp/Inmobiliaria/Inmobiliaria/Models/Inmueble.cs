using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models
{
    public abstract class Inmueble
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Display(Name = "Direccion")]
        public string _direccion { get; set; }
        [Display(Name = "Metros Cuadrados")]
        public int _metros { get; set; }
        [Display(Name = "Nuevo")]
        public bool _esNuevo { get; set; }
        [Display(Name = "Base")]
        public double _base { get; set; }
        [Display(Name = "Fecha de Construccion")]
        public DateOnly _fechaConstruccion { get; set; }


        public virtual double calcularRebaja() {

            DateOnly fechaActual = DateOnly.FromDateTime(DateTime.Now);

            if ((fechaActual.Year - this._fechaConstruccion.Year) <= 15)
            {
                return this._base * 0.01d;
            }
            else {
                return this._base * 0.02d;
            }
        } 
        
        public virtual double calcularPrecio() {
            double rebaja = calcularRebaja();
            return this._base - rebaja;
        }
    }
}
