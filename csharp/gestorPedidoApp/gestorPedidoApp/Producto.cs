using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorPedidoApp
{
    internal class Producto
    {
        public int id { get; set; } 
        public string nombre{ get; set; } 

        public string precio { get; set; }  
        public string existencias { get; set; }

        public Producto() {//constructor vacio
        }   
    }
}
