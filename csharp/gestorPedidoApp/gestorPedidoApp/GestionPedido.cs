using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorPedidoApp
{
    internal class GestionPedido
    {
        private Conexion conexion = new Conexion();

        public void mostrarPedidos()
        {
            string str_query = "SELECT c.nombre, c.apellido1, c.apellido2, c.telefono, fp.nombre AS forma_pago, cp.fecha, p.nombre AS producto, dp.cantidad, dp.precio " +
                "FROM cabecera_pedido cp " +
                "INNER JOIN cliente c ON cp.id_cliente = c.id " +
                "INNER JOIN forma_pago fp ON cp.id_forma_pago = fp.id " +
                "INNER JOIN detalle_pedido dp ON cp.id = dp.id_cabecera_pedido " +
                "INNER JOIN producto p ON dp.id_producto = p.id;";

            conexion.openConn();

            try
            {
                MySqlCommand cmd = new MySqlCommand(str_query, conexion.getConn());
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("------Datos cliente-----");
                    Console.WriteLine("\tnombre:" + reader[0]);
                    Console.WriteLine("\tapellidos: " +reader[1] + " " + reader[2]);
                    Console.WriteLine("\ttelefono: " + reader[3]);
                    Console.WriteLine("------Datos pedido-------");
                    Console.WriteLine("\tmetodo pago: " + reader[4]);
                    Console.WriteLine("\tfecha: " + reader[5]);
                    Console.WriteLine("\tproducto: " + reader[6]);
                    Console.WriteLine("\tcantidad: " + reader[7]);
                    Console.WriteLine("\tprecio: " + reader[8]);

                    Console.Write("\n\n");
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("ERROR EN GestionPedido" + e.ToString());
            }
            finally { 
                conexion.closeConn();   
            }   
        }//end mostrarPedidos()

        public void altaCliente() { 
            Cliente cliente = new Cliente();
            Console.WriteLine("Como te llamas");
            //DOING...
        }
    }
}
