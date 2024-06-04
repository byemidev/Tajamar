using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace gestorPedidoApp
{
    internal class gestionProductos
    {
        public List<Producto> listaProductos = new List<Producto>();

        public List<Producto> cargarProductos(MySqlConnection conexion) {
            
            string str_query = $"SELECT * FROM producto;";
            MySqlCommand cmd = new MySqlCommand(str_query, conexion);
            MySqlDataReader reader= cmd.ExecuteReader();   

            while (reader.Read())
            {
                listaProductos.Add(new Producto()); //TODO: pasar por parametro reader[n] para construir obejetos Produto
            }

            return this.listaProductos;
        }
    }
}
