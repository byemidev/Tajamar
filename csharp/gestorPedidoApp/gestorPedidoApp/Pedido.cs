using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorPedidoApp
{
    internal class Pedido
    {
        public Cliente cliente { get; set; }
        public List<Producto> listaProductos { get; set; }
        public MetodoPago metodo { get; set; }
        public DateTime fecha { get; set; }

        public Pedido() { 
            this.cliente = new Cliente();
            this.listaProductos = new List<Producto>(); 
            this.metodo = new MetodoPago();
            this.fecha = DateTime.Now;
        }
    }
}
