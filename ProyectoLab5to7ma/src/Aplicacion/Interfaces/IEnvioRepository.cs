namespace Aplicacion.Interfaces;

public interface IEnvioRepository
{
    void CambiarEstado(int idEnvio, string nuevoEstado);

    void Cancelar(int idEnvio);

    string ObtenerEstado(int idEnvio);

    void RegistrarEnvio(
        int idCliente,
        int idPaquete,
        int idOrigen,
        int idDestino,
        double distancia,
        string modalidad
    );
}