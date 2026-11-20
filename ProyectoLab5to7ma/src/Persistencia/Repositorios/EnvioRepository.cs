
using Aplicacion.Interfaces;
using Dapper;
using Persistencia.Conexion;

namespace Persistencia.Repositorios;

public class EnvioRepository : IEnvioRepository
{
    private readonly ConexionAdministrador conexionAdministrador;
    private readonly ConexionDesarrollo conexionDesarrollo;

    public EnvioRepository(
        ConexionAdministrador conexionAdministrador,
        ConexionDesarrollo conexionDesarrollo)
    {
        this.conexionAdministrador = conexionAdministrador;
        this.conexionDesarrollo = conexionDesarrollo;
    }

    // CAMBIAR ESTADO: ADMINISTRADOR
    public void CambiarEstado(int idEnvio, string nuevoEstado)
    {
        using var connection = conexionAdministrador.CrearConexion();

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

    // CANCELAR: ADMINISTRADOR
    public void Cancelar(int idEnvio)
    {
        using var connection = conexionAdministrador.CrearConexion();

        connection.Execute(
            "cancelarEnvio",
            new { p_idEnvio = idEnvio },
            commandType: System.Data.CommandType.StoredProcedure
        );
    }

    // OBTENER ESTADO: DESARROLLO
    public string ObtenerEstado(int idEnvio)
    {
        using var connection = conexionDesarrollo.CrearConexion();

        return connection.QueryFirst<string>(
            "SELECT estado FROM Envio WHERE idEnvio = @idEnvio",
            new { idEnvio }
        );
    }

    // REGISTRAR ENVÍO: ADMINISTRADOR
    public int RegistrarEnvio(
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
        using var connection = conexionAdministrador.CrearConexion();

        return connection.QuerySingle<int>(
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

    // ACTUALIZAR ENVÍO: ADMINISTRADOR
    public bool ActualizarEnvio(
        int idEnvio,
        string modalidad,
        double pesoKg,
        double distanciaKm,
        string calle,
        string direccionPostal,
        string localidad)
    {
        using var connection = conexionAdministrador.CrearConexion();

        if (connection.State != System.Data.ConnectionState.Open)
        {
            connection.Open();
        }

        using var transaccion = connection.BeginTransaction();

        int? idPaquete = connection.QueryFirstOrDefault<int?>(
            "SELECT idPaquete FROM Envio WHERE idEnvio = @idEnvio",
            new { idEnvio },
            transaccion
        );

        int? idDestino = connection.QueryFirstOrDefault<int?>(
            "SELECT idDestino FROM Envio WHERE idEnvio = @idEnvio",
            new { idEnvio },
            transaccion
        );

        if (idPaquete == null || idDestino == null)
        {
            transaccion.Rollback();
            return false;
        }

        connection.Execute(
            "UPDATE Paquete SET peso = @pesoKg WHERE idPaquete = @idPaquete",
            new { pesoKg, idPaquete },
            transaccion
        );

        connection.Execute(
            @"UPDATE Direccion
              SET calle = @calle,
                  direccionPostal = @direccionPostal,
                  localidad = @localidad
              WHERE idDireccion = @idDestino",
            new
            {
                calle,
                direccionPostal,
                localidad,
                idDestino
            },
            transaccion
        );

        connection.Execute(
            @"UPDATE Envio
              SET modalidad = @modalidad,
                  distancia = @distanciaKm
              WHERE idEnvio = @idEnvio",
            new
            {
                modalidad,
                distanciaKm,
                idEnvio
            },
            transaccion
        );

        transaccion.Commit();

        return true;
    }

    // LISTAR ENVÍOS: DESARROLLO
    public IEnumerable<DatosEnvio> ListarEnvios()
    {
        using var connection = conexionDesarrollo.CrearConexion();

        string consulta = @"
            SELECT
                idEnvio AS IdEnvio,
                idCliente AS IdCliente,
                idPaquete AS IdPaquete,
                idOrigen AS IdOrigen,
                idDestino AS IdDestino,
                distancia AS Distancia,
                modalidad AS Modalidad,
                estado AS Estado,
                fechaCreacion AS FechaCreacion
            FROM Envio
            ORDER BY idEnvio";

        return connection.Query<DatosEnvio>(consulta);
    }

    // HISTORIAL: DESARROLLO
    public IEnumerable<string> ObtenerHistorialEstado(int idEnvio)
    {
        using var connection = conexionDesarrollo.CrearConexion();

        return connection.Query<string>(
            "SELECT CONCAT(estado, ' - ', fecha) " +
            "FROM HistorialEstado " +
            "WHERE idEnvio = @idEnvio " +
            "ORDER BY fecha",
            new { idEnvio }
        );
    }

    // ESTADÍSTICAS: DESARROLLO
    public IEnumerable<string> ObtenerEstadisticas(
        DateTime fechaDesde,
        DateTime fechaHasta)
    {
        using var connection = conexionDesarrollo.CrearConexion();

        var resultados = connection.Query(
            "obtenerEstadisticas",
            new
            {
                p_fechaDesde = fechaDesde,
                p_fechaHasta = fechaHasta
            },
            commandType: System.Data.CommandType.StoredProcedure
        );

        List<string> estadisticas = new List<string>();

        foreach (var resultado in resultados)
        {
            estadisticas.Add(
                "Modalidad: " + resultado.modalidad +
                " | Cantidad: " + resultado.cantidadEnvios +
                " | Costo acumulado: " + resultado.costoAcumulado +
                " | Costo promedio: " + resultado.costoPromedio +
                " | Entregados: " + resultado.entregados +
                " | Cancelados: " + resultado.cancelados +
                " | Pendientes: " + resultado.pendientes +
                " | Tiempo promedio: " + resultado.tiempoPromedioEntregaHoras + " horas" +
                " | Facturación: " + resultado.facturacion
            );
        }

        return estadisticas;
    }

    // OBTENER ENVÍO POR ID: DESARROLLO
    public string? ObtenerEnvioPorId(int idEnvio)
    {
        using var connection = conexionDesarrollo.CrearConexion();

        string consulta = @"
            SELECT
                idEnvio,
                idCliente,
                idPaquete,
                idOrigen,
                idDestino,
                distancia,
                modalidad,
                estado,
                fechaCreacion
            FROM Envio
            WHERE idEnvio = @idEnvio";

        var envio = connection.QueryFirstOrDefault(
            consulta,
            new { idEnvio }
        );

        if (envio == null)
            return null;

        return System.Text.Json.JsonSerializer.Serialize(envio);
    }

    // COTIZACIÓN: DESARROLLO
    public DatosCotizacion? ObtenerDatosCotizacion(int idEnvio)
    {
        using var connection = conexionDesarrollo.CrearConexion();

        string consulta = @"
            SELECT
                e.modalidad AS Modalidad,
                p.peso AS PesoKg,
                e.distancia AS DistanciaKm
            FROM Envio e
            INNER JOIN Paquete p ON e.idPaquete = p.idPaquete
            WHERE e.idEnvio = @idEnvio";

        return connection.QueryFirstOrDefault<DatosCotizacion>(
            consulta,
            new { idEnvio }
        );
    }
}
