using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using MySql.Data.MySqlClient;
using Mysqlx.Cursor;
using MySqlX.XDevAPI;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace gestorPedidoApp
{
    internal class GestionCabecera
    {
        List<CabeceraPedido> listaCabeceras = new List<CabeceraPedido>();

        public int insertarCabeceras(MySqlConnection conexion,  Cliente cliente, MetodoPago metodo, DateTime fecha) { //DOING REVISAR
            string str_query = $"sp_InsertarCabecera";
            //Deberia devolver el id de la cabecera una vez se inserta, con un procedimiento almacenado , con los 3 argumentos de entrada de este metodo y de salida el id_cabecera que necesito para detalle
            using (MySqlCommand cmd = new MySqlCommand(str_query, conexion)) {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;


                cmd.ExecuteNonQuery();

                int id_cabecera = -1;

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()){
                    id_cabecera = reader.GetInt32("id_cabecera");
                    this.listaCabeceras.Add(new CabeceraPedido(id_cabecera));
                }

                return id_cabecera;
            }
        }
    }
}
