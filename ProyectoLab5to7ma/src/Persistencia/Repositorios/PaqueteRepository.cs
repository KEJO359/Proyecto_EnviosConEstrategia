using Dapper;
using Persistencia.Conexion;
using Persistencia.Entidades;

namespace Persistencia.Repositorios;

public class PaqueteRepository
{
    private readonly IDBConnectionFactory conexion;

    public PaqueteRepository(IDBConnectionFactory conexion)
    {
        this.conexion = conexion;
    }

    public void Registrar(Paquete paquete)
    {
        using var connection = conexion.CrearConexion();

        connection.Execute(
            "INSERT INTO Paquete " +
            "(peso, alto, ancho, largo) " +
            "VALUES " +
            "(@Peso, @Altura, @Ancho, @Largo)",
            paquete);
    }

    public Paquete ObtenerPorId(int idPaquete)
    {
        using var connection = conexion.CrearConexion();

        return connection.QueryFirst<Paquete>(
            "SELECT peso AS Peso, " +
            "alto AS Altura, " +
            "ancho AS Ancho, " +
            "largo AS Largo " +
            "FROM Paquete " +
            "WHERE idPaquete = @idPaquete",
            new
            {
                idPaquete
            });
    }
}