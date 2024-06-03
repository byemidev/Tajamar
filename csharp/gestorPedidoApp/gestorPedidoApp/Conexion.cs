using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace gestorPedidoApp
{
    internal class Conexion
    {
        private MySqlConnection connection = null;
        private string server = ConfigurationManager.AppSettings["server"];
        private string database = ConfigurationManager.AppSettings["database"];
        private string user = ConfigurationManager.AppSettings["user"];
        private string password = ConfigurationManager.AppSettings["password"];
        public Conexion() {
             this.connection = new MySqlConnection($"server={server};database={database};user={user};password={password}");
            Console.WriteLine("conectado a base de datos");
        }   

        public void openConn()
        {
            try { 
            this.connection.Open();
                Console.WriteLine("conexion abierta");
            }catch(Exception e)
            {
                Console.WriteLine("Error al abrir conexion" + e.ToString());    
            }
            
        }

        public void closeConn() {
            try
            {
            this.connection?.Close();
            }catch (Exception e)  { 
                Console.WriteLine("error al cerrar la conexion"  + e.ToString());
            }

        }

        public MySqlConnection getConn()
        {
            return this.connection;
        }

    }
}
