
namespace Aplicacion.Interfaces;

public interface IEnvioRepository
{
    void CambiarEstado(int idEnvio, string nuevoEstado);

    void Cancelar(int idEnvio);

    string ObtenerEstado(int idEnvio);

    int RegistrarEnvio(
        int idCliente,
        int idOrigen,
        int idDestino,
        double peso,
        double alto,
        double ancho,
        double largo,
        double distancia,
        string modalidad
    );

    bool ActualizarEnvio(
        int idEnvio,
        string modalidad,
        double pesoKg,
        double distanciaKm,
        string calle,
        string direccionPostal,
        string localidad
    );

    IEnumerable<DatosEnvio> ListarEnvios();

    IEnumerable<string> ObtenerHistorialEstado(int idEnvio);

    IEnumerable<string> ObtenerEstadisticas(
        DateTime fechaDesde,
        DateTime fechaHasta
    );

    string? ObtenerEnvioPorId(int idEnvio);

    DatosCotizacion? ObtenerDatosCotizacion(int idEnvio);
}

public record DatosEnvio(
    int IdEnvio,
    int IdCliente,
    int IdPaquete,
    int IdOrigen,
    int IdDestino,
    decimal Distancia,
    string Modalidad,
    string Estado,
    DateTime FechaCreacion
);

public record DatosCotizacion(
    string Modalidad,
    decimal PesoKg,
    decimal DistanciaKm
);
