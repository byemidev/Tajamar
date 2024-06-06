using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace gestorPedidoApp
{
    internal class GestionProducto
    {
        public List<Producto> listaProductos = new List<Producto>();

        public void cargarProductos(MySqlConnection conexion) {
            
            string str_query = $"SELECT * FROM producto;";
            MySqlCommand cmd = new MySqlCommand(str_query, conexion);
            MySqlDataReader reader= cmd.ExecuteReader();   

            while (reader.Read())
            {
                listaProductos.Add(new Producto(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetInt32(3)));
            }

            listarProductos();
        }

        public void listarProductos()
        {
            Console.WriteLine("------------------------- PRODUCTOS --------------------------");

            this.listaProductos.ForEach(
                    (Producto) => Console.WriteLine("\nId: "    + Producto.id 
                    + "\nNombre: "                              + Producto.nombre
                    + "\nPrecio: "                              + Producto.precio + "€"
                    + "\nExistencias: "                         + Producto.existencias
                    )
                ); 
        }
    }

    
}
