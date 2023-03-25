using System.Data;
using System.Data.SqlClient;

namespace BE_CRUDMascotas.AccesoDatos.ConexionBd
{
    public class ConexioBd
    {
        private readonly string _conexion;
        private readonly IConfiguration _config;

        public ConexioBd(IConfiguration config)
        {
            _config = config;

            _conexion = _config.GetConnectionString("Conexion");
        }

        public IDbConnection Conectar() => new SqlConnection(_conexion);
    }
}
