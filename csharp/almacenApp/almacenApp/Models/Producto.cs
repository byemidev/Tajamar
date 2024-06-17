using System.Globalization;

namespace almacenApp.Models
{
    public class Producto
    {
        public int id_producto { get; set; } //autoincrement in data base
        public string nombre { get; set; }  
        public int stock_cantidad { get; set; }
        public int categoria { get; set; }    
        public double precio { get; set; } 
        
        
        public Producto() { 
        
        }
        //todo: constructor
        public Producto(string nombre, int stock_catidad, int categoria, double precio ) { 
            this.nombre = nombre;   
            this.stock_cantidad = stock_catidad;
            this.categoria = categoria;
            this.precio = precio;
        }

    }
}

