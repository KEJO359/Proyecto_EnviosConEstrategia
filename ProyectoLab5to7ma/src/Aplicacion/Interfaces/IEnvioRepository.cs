namespace Aplicacion.Interfaces;

public interface IEnvioRepository
{
    void CambiarEstado(int idEnvio, string nuevoEstado);

    void Cancelar(int idEnvio);

    string ObtenerEstado(int idEnvio);

    void RegistrarEnvio(
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
}