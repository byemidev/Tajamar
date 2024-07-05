using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models
{
    public abstract class Inmueble
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string direccion { get; set; }
        public int metros { get; set; }
        public bool es_nuevo { get; set; }
        public double precio_base { get; set; }
        public DateOnly fecha_construccion { get; set; }


        public virtual double calcularRebaja() {

            DateOnly fechaActual = DateOnly.FromDateTime(DateTime.Now);

            if ((fechaActual.Year - this.fecha_construccion.Year) <= 15)
            {
                return this.precio_base * 0.01d;
            }
            else {
                return this.precio_base * 0.02d;
            }
        } 
        
        public virtual double calcularPrecio() {
            double rebaja = calcularRebaja();
            return this.precio_base - rebaja;
        }
    }
}
