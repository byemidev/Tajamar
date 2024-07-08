using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models
{
    public class Inmueble : iInmueble
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id { get; set; }
        public string? direccion { get; set; }
        public int? metros { get; set; }
        public bool? es_nuevo { get; set; }
        public double? precio_base { get; set; }
        public DateOnly? fecha_construccion { get; set; }

        public Inmueble() { 
            //constructor vacio
        }

        public Inmueble(string? direccion, int? metros, bool? es_nuevo, double? precio_base, DateOnly? fecha_construccion) { 
            this.direccion = direccion;
            this.metros = metros;   
            this.es_nuevo = es_nuevo;
            this.precio_base = precio_base;
            this.fecha_construccion = fecha_construccion;
        }

        public virtual double? calcularRebaja() {

            DateOnly? fechaActual = DateOnly.FromDateTime(DateTime.Now);

            if ((fechaActual.Value.Year - this.fecha_construccion.Value.Year) <= 15)
            {
                return this.precio_base * 0.01d;
            }
            else {
                return this.precio_base * 0.02d;
            }
        } 
        
        public virtual double? calcularPrecio() {
            double? rebaja = calcularRebaja();
            return this.precio_base - rebaja;
        }
    }
}
