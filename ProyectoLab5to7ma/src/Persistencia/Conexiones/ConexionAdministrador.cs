
using System.Data;
using MySqlConnector;

namespace Persistencia.Conexion;

public class ConexionAdministrador : IDBConnectionFactory
{
    private readonly string connectionString =
        Environment.GetEnvironmentVariable("DB_ADMIN_CONNECTION")
        ?? throw new InvalidOperationException("No se encontró la variable DB_ADMIN_CONNECTION.");

    public IDbConnection CrearConexion()
    {
        return new MySqlConnection(connectionString);
    }
}
