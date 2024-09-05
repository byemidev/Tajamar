using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;

namespace WebAPI.Modelo
{
    public class Proceso
    {
        ConexionBD c;
        public Proceso()
        {
            c = new ConexionBD();
        }
        /*
         *
         *
         *ALGORITMO:
         *
         * Si el numero existe devolver la informacion
         * Si el numero no existe quitar una cifra por detras
         * Repetir hasta que coincida con el patron 
         */

        
        public string ConsultarTabla(String dato)
        {
            using (var connection = new SqlConnection((string)c.GetConexion()))
            {
                connection.Open();


                // Crea un objeto SqlCommand con la consulta SELECT
                SqlCommand command = new SqlCommand("SELECT * FROM Routing WHERE numeracion = @numeracion", connection);
                command.Parameters.AddWithValue("@numeracion", dato);
                String name = "DEFAULT";
                // Ejecuta la consulta y obtiene los resultados en un objeto SqlDataReader
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Accede a los datos de cada fila utilizando los métodos GetXxx del objeto SqlDataReader
                        int id = reader.GetInt32(0);
                        name = reader.GetString(2);
                        // ... accede a otros campos de la tabla según sea necesario

                        return name;
                    }
                    else
                    {
                        if (dato.Length == 1) return name;
                        dato = dato.Substring(0, dato.Length - 1);
                        return ConsultarTabla(dato);
                         
                    }

                    
                }

                return name;
            }

        }
    }
}
