

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace WebAPI.Modelo
{
 

    public class ConexionBD
    {
        private string connectionString;
        private SqlConnection connection;

        public ConexionBD()
        {
            // Establece la cadena de conexión a tu base de datos
            // connectionString = "Data Source=T24W25\\MSSQLSERVER2;Initial Catalog=prueba;User ID=sa;Password=sa;Encrypt=False";
            var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

             connectionString = configuration.GetConnectionString("MyConnectionString");

            connection = new SqlConnection(connectionString);
        }

        public void AbrirConexion()
        {
            // Abre la conexión a la base de datos
            connection.Open();
        }

        public void CerrarConexion()
        {
            // Cierra la conexión a la base de datos
            connection.Close();
        }

        internal string GetConexion()
        {
            return connectionString;


        }

        // Aquí puedes agregar métodos para ejecutar consultas, insertar datos, etc.
    }
}
