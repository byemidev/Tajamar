using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace empleadosCRUD
{
    internal class SGBD
    {
        //taken data conection from ConsigurationManager.appSettigns
        private static string servidor = ConfigurationManager.AppSettings["server"];
        private static string database = ConfigurationManager.AppSettings["database"];
        private static string user = ConfigurationManager.AppSettings["user"];
        private static string password = ConfigurationManager.AppSettings["password"];


        private  string conn_str = $"server={servidor};database={database};user={user};password={password}";
        private  MySqlConnection conn= null;    

        public SGBD() { 
            //constructor vacio
        }

        public void updateEmpleados(Empleado emp)
        {
            //todo update empleado
        }

        public void openConn()
        {
            conn = new MySqlConnection(conn_str);
            conn.Open();
        }

        public void closeConn()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public void insertEmpleado(Empleado empleado)
        {
            string str_query = "INSERT INTO empleado (nif, nombre, apellido1, apellido2, codigo_departamento) VALUES (@val1, @val2, @val3, @val4, @val5);";

            try
            {
                MySqlCommand cmd = new MySqlCommand(str_query, getConnection());
                cmd.Parameters.AddWithValue("@val1", empleado.getNif());
                cmd.Parameters.AddWithValue("@val2", empleado.getNombre());
                cmd.Parameters.AddWithValue("@val3", empleado.getApellido1());
                cmd.Parameters.AddWithValue("@val4", empleado.getApellido2());
                cmd.Parameters.AddWithValue("@val5", empleado.getCodigoDep());
                cmd.Prepare();

                cmd.ExecuteNonQuery();
                Console.Write("empleado insertado");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("ERROR CREANDO EMPLEADO" + e.Message);
            }
        }

        public void insertDepartamento(Departamento dep)
        {
            string str_query = "INSERT INTO departamento (nombre, presupuesto, gastos) VALUES (@val1, @val2, @val3);";
            try {      
                MySqlCommand cmd = new MySqlCommand(str_query, getConnection());
                cmd.Parameters.AddWithValue("@val1", dep.nombre);
                cmd.Parameters.AddWithValue("@val2", dep.presupuesto);
                cmd.Parameters.AddWithValue("@val3", dep.gastos);
                cmd.Prepare();

                cmd.ExecuteNonQuery();
                Console.Write("departamento insertado");
            }
            catch (Exception e) { 
                Console.WriteLine("error insertando dep" + e.Message);
            }
        }

        


        public void deletingEmpleado(int id_empleado)
        {
            string str_query = $"DELETE FROM empleado WHERE codigo={id_empleado};";
            MySqlCommand cmd = new MySqlCommand(str_query, getConnection());

            try { 
                cmd.ExecuteNonQuery();
                Console.WriteLine($"empleado {id_empleado} eliminado.");
            }catch (Exception e) 
            { 
                Console.WriteLine("Error en borrado de empleado" + e.Message); 
            }
        }

        public void deletingDepartamento(int id_departamento)
        {
            string str_query = $"DELETE FROM departamento WHERE codigo={id_departamento};";
            MySqlCommand cmd = new MySqlCommand(str_query, getConnection());

            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine($"departamento {id_departamento} eliminado. ");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en borrado de empleado" + e.Message);
            }
        }

        public void readEmpleados()
        {
            string str_query = "select * from empleado";
            List<Empleado> listaEmpleados = new List<Empleado>();


            try
            {
                MySqlCommand cmd = new MySqlCommand(str_query, getConnection());
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Empleado emp = new Empleado();

                    emp.setCodigo(int.Parse(reader["codigo"].ToString()));
                    emp.setNif(reader["nif"].ToString());
                    emp.setNombre(reader["nombre"].ToString());
                    emp.setApellido1(reader["apellido1"].ToString());
                    emp.setApellido2(reader["apellido2"].ToString());
                    emp.setCodigoDep(int.Parse(reader["codigo_departamento"].ToString()));

                    listaEmpleados.Add(emp);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en lectura de empleados" + e.Message);
            }
            finally
            {
                foreach (Empleado o in listaEmpleados)
                {
                    Console.WriteLine("Nombre: " + o.getNombre() + " Apellidos: " + o.getApellido1() + " " + o.getApellido2());
                }
            }
        }

        public MySqlConnection getConnection()
        {
            return this.conn;
        }
    }
}
