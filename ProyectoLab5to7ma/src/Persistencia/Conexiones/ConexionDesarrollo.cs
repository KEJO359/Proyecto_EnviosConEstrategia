
using System.Data;
using MySqlConnector;

namespace Persistencia.Conexion;

public class ConexionDesarrollo : IDBConnectionFactory
{
    private readonly string connectionString =
        Environment.GetEnvironmentVariable("DB_DESARROLLO_CONNECTION")
        ?? throw new InvalidOperationException("No se encontró la variable DB_DESARROLLO_CONNECTION.");

    public IDbConnection CrearConexion()
    {
        return new MySqlConnection(connectionString);
    }
}
