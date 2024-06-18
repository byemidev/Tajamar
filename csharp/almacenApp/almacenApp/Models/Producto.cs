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
    }
}

