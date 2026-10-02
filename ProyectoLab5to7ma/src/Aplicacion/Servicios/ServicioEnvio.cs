using Aplicacion.Interfaces;

namespace Aplicacion.Servicios;

public class ServicioEnvio
{
    private readonly IEnvioRepository repositorio;

    public ServicioEnvio(IEnvioRepository repositorio)
    {
        this.repositorio = repositorio;
    }

    public void CambiarEstado(int idEnvio, string nuevoEstado)
    {
        if (idEnvio <= 0)
        {
            throw new Exception("El ID del envío debe ser mayor que cero.");
        }

        if (string.IsNullOrWhiteSpace(nuevoEstado))
        {
            throw new Exception("El estado es obligatorio.");
        }

        nuevoEstado = nuevoEstado.ToUpper();

        if (nuevoEstado != "PENDIENTE" &&
            nuevoEstado != "EN_PROCESO" &&
            nuevoEstado != "ENTREGADO" &&
            nuevoEstado != "CANCELADO")
        {
            throw new Exception("El estado no es válido.");
        }

        string estadoActual = repositorio.ObtenerEstado(idEnvio);

        if (estadoActual == "ENTREGADO" ||
            estadoActual == "CANCELADO")
        {
            throw new Exception("El envío ya no puede cambiar de estado.");
        }

        if (estadoActual == "PENDIENTE" &&
            nuevoEstado != "EN_PROCESO" &&
            nuevoEstado != "CANCELADO")
        {
            throw new Exception("Un envío pendiente solo puede pasar a EN_PROCESO o CANCELADO.");
        }

        if (estadoActual == "EN_PROCESO" &&
            nuevoEstado != "ENTREGADO" &&
            nuevoEstado != "CANCELADO")
        {
            throw new Exception("Un envío en proceso solo puede pasar a ENTREGADO o CANCELADO.");
        }

        repositorio.CambiarEstado(idEnvio, nuevoEstado);
    }

    public void Cancelar(int idEnvio)
    {
        if (idEnvio <= 0)
        {
            throw new Exception("El ID del envío debe ser mayor que cero.");
        }

        string estadoActual = repositorio.ObtenerEstado(idEnvio);

        if (estadoActual == "ENTREGADO")
        {
            throw new Exception("No se puede cancelar un envío entregado.");
        }

        if (estadoActual == "CANCELADO")
        {
            throw new Exception("El envío ya está cancelado.");
        }

        repositorio.Cancelar(idEnvio);
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
        if (idCliente <= 0)
        {
            throw new Exception("El ID del cliente debe ser mayor que cero.");
        }

        if (idOrigen <= 0)
        {
            throw new Exception("El ID del origen debe ser mayor que cero.");
        }

        if (idDestino <= 0)
        {
            throw new Exception("El ID del destino debe ser mayor que cero.");
        }

        if (peso <= 0)
        {
            throw new Exception("El peso debe ser mayor que cero.");
        }

        if (alto <= 0)
        {
            throw new Exception("El alto debe ser mayor que cero.");
        }

        if (ancho <= 0)
        {
            throw new Exception("El ancho debe ser mayor que cero.");
        }

        if (largo <= 0)
        {
            throw new Exception("El largo debe ser mayor que cero.");
        }

        if (distancia <= 0)
        {
            throw new Exception("La distancia debe ser mayor que cero.");
        }

        if (string.IsNullOrWhiteSpace(modalidad))
        {
            throw new Exception("La modalidad es obligatoria.");
        }

        modalidad = modalidad.ToUpper();

        if (modalidad != "ESTANDAR" &&
            modalidad != "EXPRESS" &&
            modalidad != "PRIORITARIO")
        {
            throw new Exception("La modalidad no es válida.");
        }

        repositorio.RegistrarEnvio(
            idCliente,
            idOrigen,
            idDestino,
            peso,
            alto,
            ancho,
            largo,
            distancia,
            modalidad
        );
    }

    public IEnumerable<string> ListarEnvios()
    {
        return repositorio.ListarEnvios();
    }

    public IEnumerable<string> ObtenerHistorialEstado(int idEnvio)
    {
        if (idEnvio <= 0)
        {
            throw new Exception("El ID del envío debe ser mayor que cero.");
        }

        return repositorio.ObtenerHistorialEstado(idEnvio);
    }

    public IEnumerable<string> ObtenerEstadisticas(
        DateTime fechaDesde,
        DateTime fechaHasta)
    {
        if (fechaDesde > fechaHasta)
        {
            throw new Exception("La fecha desde no puede ser mayor que la fecha hasta.");
        }

        return repositorio.ObtenerEstadisticas(
            fechaDesde,
            fechaHasta);
    }
}