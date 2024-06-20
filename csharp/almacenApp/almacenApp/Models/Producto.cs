using System.Globalization;

namespace almacenApp.Models
{
    public class Producto
    {
        public int id_producto { get; set; } //autoincrement in data base
        public string nombre { get; set; }  
        public int stock_cantidad { get; set; }
        public int categoria { get; set; }    
        public decimal precio { get; set; }


        public Producto(int id_producto, string nombre, int stock_cantidad, int categoria, decimal precio) { 
            this.id_producto = id_producto;
            this.nombre = nombre;
            this.stock_cantidad = stock_cantidad;
            this.categoria = categoria; 
            this.precio = precio;
        }

        public Producto()
        {
            //constructor vacio 
        }

    }
}

