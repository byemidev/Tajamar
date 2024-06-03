using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorPedidoApp
{
    internal class DetallePedido
    {
        int id_cabecera_pedido { get; set; }
        int secuencia { get; set; }
        int id_producto { get; set; }   
        int cantidad { get; set; }  
        double precio { get; set; } 

        public DetallePedido() { }  

    }
}
