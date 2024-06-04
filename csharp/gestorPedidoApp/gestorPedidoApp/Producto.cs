﻿using System;
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

        public double precio { get; set; }  
        public string existencias { get; set; }

        public Producto() {//constructor vacio
        }

        public Producto(int id, string nombre, double precio, string existencias) { 
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.existencias = existencias;           
        }
    }
}
