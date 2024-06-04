using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorPedidoApp
{
    internal class Cliente
    {
        public int id { get; set; } 
        public string nombre { get; set; }    
        public string apellido1 { get; set; }
        
        public string apellido2 { get; set; }

        public string telefono { get; set; }

        public Cliente() { //constructor vacio
        }

        public Cliente(string nombre , string apellido1, string apellido2, string telefono) { 
            this.nombre = nombre;
            this.apellido1 = apellido1; 
            this.apellido2 = apellido2; 
            this.telefono = telefono;   
        }
    }
}
