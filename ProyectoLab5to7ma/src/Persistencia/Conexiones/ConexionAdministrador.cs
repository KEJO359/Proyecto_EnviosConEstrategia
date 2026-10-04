using System.Data;
using MySqlConnector;

namespace Persistencia.Conexion;

public class ConexionAdministrador : IDBConnectionFactory
{
    private readonly string connectionString =
        "Server=localhost;Database=DB_JoacoEnvios;User ID=administrador;Password=admin123;";

    public IDbConnection CrearConexion()
    {
        return new MySqlConnection(connectionString);
    }
}