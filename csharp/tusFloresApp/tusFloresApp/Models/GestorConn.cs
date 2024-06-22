using System.Data.SqlClient;

namespace tusFloresApp.Models
{
    public class GestorConn 
    {
        private readonly SqlConnection  _conn;
        
        public GestorConn(IConfiguration configuration) {
            this._conn = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        //abre la conexion
        public void openConn() {
            try { 
                _conn.Open();
            }catch(Exception ex){
                throw ex;
            }    
        }
        //cierra la conexion
        public void closeConn() {
            try
            {
                _conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //devuelve la conexion
        public SqlConnection getConection() { 
            return _conn;
        }
    }
}
