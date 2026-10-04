using System.Data;
using MySqlConnector;

namespace Persistencia.Conexion;

public class ConexionDesarrollo : IDBConnectionFactory
{
    private readonly string connectionString =
        "Server=localhost;Database=DB_JoacoEnvios;User ID=desarrollo;Password=desarrollo123;";

    public IDbConnection CrearConexion()
    {
        return new MySqlConnection(connectionString);
    }
}