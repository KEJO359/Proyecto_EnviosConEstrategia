using Dapper;
using Persistencia.Conexion;
using Persistencia.Entidades;

namespace Persistencia.Repositorios;

public class ClienteRepository
{
    private readonly IDBConnectionFactory conexion;

    public ClienteRepository(IDBConnectionFactory conexion)
    {
        this.conexion = conexion;
    }

    public void Registrar(Cliente cliente)
    {
        using var connection = conexion.CrearConexion();

        connection.Execute(
            "INSERT INTO Cliente " +
            "(nombre, apellido, dni, telefono, email) " +
            "VALUES " +
            "(@Nombre, @Apellido, @Dni, @Telefono, @Email)",
            cliente);
    }

    public Cliente ObtenerPorId(int idCliente)
    {
        using var connection = conexion.CrearConexion();

        return connection.QueryFirst<Cliente>(
            "SELECT nombre AS Nombre, apellido AS Apellido, " +
            "dni AS Dni, telefono AS Telefono, email AS Email " +
            "FROM Cliente " +
            "WHERE idCliente = @idCliente",
            new
            {
                idCliente
            });
    }
}