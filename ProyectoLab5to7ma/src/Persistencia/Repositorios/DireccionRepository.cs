using Dapper;
using Persistencia.Conexion;
using Persistencia.Entidades;

namespace Persistencia.Repositorios;

public class DireccionRepository
{
    private readonly IDBConnectionFactory conexion;

    public DireccionRepository(IDBConnectionFactory conexion)
    {
        this.conexion = conexion;
    }

    public void Registrar(Direccion direccion)
    {
        using var connection = conexion.CrearConexion();

        connection.Execute(
            "INSERT INTO Direccion " +
            "(calle, direccionPostal, localidad) " +
            "VALUES " +
            "(@Calle, @DireccionPostal, @Localidad)",
            direccion);
    }

    public Direccion ObtenerPorId(int idDireccion)
    {
        using var connection = conexion.CrearConexion();

        return connection.QueryFirst<Direccion>(
            "SELECT calle AS Calle, " +
            "direccionPostal AS DireccionPostal, " +
            "localidad AS Localidad " +
            "FROM Direccion " +
            "WHERE idDireccion = @idDireccion",
            new
            {
                idDireccion
            });
    }
}