using Aplicacion.Interfaces;
using Dapper;
using Persistencia.Conexion;

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
                p_idEnvio = idEnvio,
                p_nuevoEstado = nuevoEstado
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
                p_idEnvio = idEnvio
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
        int idOrigen,
        int idDestino,
        double peso,
        double alto,
        double ancho,
        double largo,
        double distancia,
        string modalidad)
    {
        using var connection = conexion.CrearConexion();

        connection.Execute(
            "altaEnvioCompleto",
            new
            {
                p_idCliente = idCliente,
                p_idOrigen = idOrigen,
                p_idDestino = idDestino,
                p_peso = peso,
                p_alto = alto,
                p_ancho = ancho,
                p_largo = largo,
                p_distancia = distancia,
                p_modalidad = modalidad
            },
            commandType: System.Data.CommandType.StoredProcedure
        );
    }
}