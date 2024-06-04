using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorPedidoApp
{
    internal class GestionCliente
    {
        
        public void altaCliente(MySqlConnection conexion, Cliente cliente) { 
            
            //creating query 
            string str_query = $"INSERT INTO cliente (nombre, apellido1, apellido2, telefono) VALUES ('{cliente.nombre}', '{cliente.apellido1}', '{cliente.apellido2}', '{cliente.telefono}')";
            //creating cmd 
            MySqlCommand cmd = new MySqlCommand(str_query, conexion);
            //executing 
            cmd.ExecuteNonQuery();  
        }

        public bool clienteExiste(MySqlConnection conexion, string telefono){
            
            string str_query = $"SELECT * FROM cliente WHERE telefono like '{telefono}'";
             
            MySqlCommand cmd = new MySqlCommand(str_query, conexion );
            MySqlDataReader reader = cmd.ExecuteReader();
            
            bool result = reader.Read();    
            reader.Close();

            return result;
        }

        public Cliente cargarCliente(MySqlConnection conexion , string telefono) {
            string str_query = $"SELECT * FROM cliente WHERE telefono='{telefono}';";
            MySqlCommand cmd = new MySqlCommand(str_query, conexion);
            MySqlDataReader reader = cmd.ExecuteReader();

            Cliente cliente = new Cliente();

            if (reader.Read())
            {
                cliente.id = reader.GetInt32(0);
                cliente.nombre = reader.GetString(1);   
                cliente.apellido1 = reader.GetString(2);    
                cliente.apellido2 = reader.GetString(3);
                cliente.telefono = telefono;
            }
            reader.Close();
            return cliente;
        }

        public Cliente recogerCliente() {
            Console.WriteLine("dando alta ....");
            Console.WriteLine("Introduce tu nombre");
            string nombre = Console.ReadLine();
            Console.WriteLine("Introduce tu apellido1");
            string apellido1 = Console.ReadLine();
            Console.WriteLine("Introduce tu apellido2");
            string apellido2 = Console.ReadLine();
            Console.WriteLine("Introduce tu telefono");
            string telefono = Console.ReadLine();

            return new Cliente(nombre, apellido1, apellido2, telefono);
        }
    }
}
