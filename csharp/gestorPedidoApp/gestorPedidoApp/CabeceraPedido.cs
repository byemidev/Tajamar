using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorPedidoApp
{
    internal class CabeceraPedido
    {
        int id { get; set; }

        int id_cliente { get; set; }

        DateTime fecha { get; set; }  

        int id_forma_pago { get; set; }

        public CabeceraPedido   () { //constructor vacio
        }  
    }
}
