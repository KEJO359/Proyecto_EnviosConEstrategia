using System.Data;

namespace Persistencia.Conexion;

public interface IDBConnectionFactory
{
    IDbConnection CrearConexion();
}