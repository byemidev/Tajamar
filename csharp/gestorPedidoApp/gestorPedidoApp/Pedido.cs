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
        private Cliente cliente;
        private List<Producto> listaProductos;
        private MetodoPago metodo;

        public Pedido() { 
            this.cliente = new Cliente();
            this.listaProductos = new List<Producto>(); 
            this.metodo = new MetodoPago();
        }
    }
}
