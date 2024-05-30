using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace empleadosCRUD
{
    internal class SGBD
    {
        private  string conn_str = "server=localhost;database=empresa;user=root;password=1234";
        private  MySqlConnection conn= null;


        public void createEmpleado(empleado empleado)
        {
            string str_query = "INSERT INTO EMPLEADOS (nif, nombre, apellido1, apellido2, codigo_departamento) VALUES ('@val1', '@val2', '@val3', '@val4', '@val5');";

            try
            {
                MySqlCommand cmd = new MySqlCommand(str_query);
                cmd.Parameters.AddWithValue("@val1", empleado.getNif());
                cmd.Parameters.AddWithValue("@val2", empleado.getNombre());
                cmd.Parameters.AddWithValue("@val3", empleado.getApellido1());
                cmd.Parameters.AddWithValue("@val4", empleado.getApellido2());
                cmd.Parameters.AddWithValue("@val5", empleado.getCodigoDep());
                cmd.Prepare();

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }

        public List<empleado> readEmpleados()
        {
            string str_query = "select * from empleados";
            return null;
        }

        public void updateEmpleados(empleado emp)
        {
            //todo update empleado
        }

        public SGBD()
        {
            try { 
                this.conn = new MySqlConnection(conn_str);
                
            }catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        public void openConn() {
            try { 
            this.conn.Open();   
            }catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message); 
            }
        }

        public void closeConn() {
            try
            {
                this.conn.Close();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }        
        }

        public MySqlConnection getConnection() { 
            return this.conn;   
        }
    }
}
