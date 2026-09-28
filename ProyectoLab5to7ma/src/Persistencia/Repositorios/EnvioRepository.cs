using Aplicacion.Interfaces;
using Dapper;
using Persistencia.Conexion;
using Persistencia.Entidades;

namespace Persistencia.Repositorios;

public class EnvioRepository : IEnvioRepository
{
    private readonly IDBConnectionFactory conexion;

    public EnvioRepository(IDBConnectionFactory conexion)
    {
        this.conexion = conexion;
    }

    public void CambiarEstado(int idEnvio, string nuevoEstado)
    {
        using var connection = conexion.CrearConexion();

        connection.Execute(
            "cambiarEstadoEnvio",
            new
            {
                un_idEnvio = idEnvio,
                un_nuevoEstado = nuevoEstado
            },
            commandType: System.Data.CommandType.StoredProcedure
        );
    }

    public void Cancelar(int idEnvio)
    {
        using var connection = conexion.CrearConexion();

        connection.Execute(
            "cancelarEnvio",
            new
            {
                un_idEnvio = idEnvio
            },
            commandType: System.Data.CommandType.StoredProcedure
        );
    }

    public string ObtenerEstado(int idEnvio)
    {
        using var connection = conexion.CrearConexion();

        return connection.QuerySingle<string>(
            "SELECT estado FROM Envio WHERE idEnvio = @idEnvio",
            new
            {
                idEnvio
            }
        );
    }

    public void RegistrarEnvio(
    int idCliente,
    int idPaquete,
    int idOrigen,
    int idDestino,
    double distancia,
    string modalidad)
{
    using var connection = conexion.CrearConexion();

    connection.Execute(
        "altaEnvioCompleto",
        new
        {
            un_idCliente = idCliente,
            un_idPaquete = idPaquete,
            un_idOrigen = idOrigen,
            un_idDestino = idDestino,
            un_distancia = distancia,
            un_modalidad = modalidad
        },
        commandType: System.Data.CommandType.StoredProcedure
    );
}
}