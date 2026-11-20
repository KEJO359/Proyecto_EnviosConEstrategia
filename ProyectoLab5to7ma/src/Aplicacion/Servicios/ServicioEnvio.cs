
using System;
using System.Collections.Generic;
using System.Linq;
using Aplicacion.Interfaces;

namespace Aplicacion.Servicios;

public class ServicioEnvio
{
    private readonly IEnvioRepository repositorio;
    private readonly Dictionary<string, IEstrategiaCotizacion> estrategias;

    public ServicioEnvio(
        IEnvioRepository repositorio,
        IEnumerable<IEstrategiaCotizacion> estrategias)
    {
        this.repositorio = repositorio;

        this.estrategias = estrategias.ToDictionary(
            estrategia => estrategia.Modalidad,
            StringComparer.OrdinalIgnoreCase
        );
    }

    public void CambiarEstado(int idEnvio, string nuevoEstado)
    {
        if (idEnvio <= 0)
            throw new Exception("El ID del envío debe ser mayor que cero.");

        if (string.IsNullOrWhiteSpace(nuevoEstado))
            throw new Exception("El estado es obligatorio.");

        nuevoEstado = nuevoEstado.ToUpper();

        if (nuevoEstado != "DESPACHADO" &&
            nuevoEstado != "ENTREGADO")
            throw new Exception("El estado no es válido.");

        string estadoActual = repositorio.ObtenerEstado(idEnvio);

        if (estadoActual == "CANCELADO" ||
            estadoActual == "ENTREGADO")
            throw new Exception("El envío ya no puede cambiar de estado.");

        if (estadoActual == "PENDIENTE" &&
            nuevoEstado != "DESPACHADO")
            throw new Exception("Un envío pendiente solo puede pasar a DESPACHADO.");

        if (estadoActual == "DESPACHADO" &&
            nuevoEstado != "ENTREGADO")
            throw new Exception("Un envío despachado solo puede pasar a ENTREGADO.");

        repositorio.CambiarEstado(idEnvio, nuevoEstado);
    }

    public void Cancelar(int idEnvio)
    {
        if (idEnvio <= 0)
            throw new Exception("El ID del envío debe ser mayor que cero.");

        string estadoActual = repositorio.ObtenerEstado(idEnvio);

        if (estadoActual == "ENTREGADO")
            throw new Exception("No se puede cancelar un envío entregado.");

        if (estadoActual == "CANCELADO")
            throw new Exception("El envío ya está cancelado.");

        repositorio.Cancelar(idEnvio);
    }

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
        if (idCliente <= 0)
            throw new Exception("El ID del cliente debe ser mayor que cero.");

        if (idOrigen <= 0)
            throw new Exception("El ID del origen debe ser mayor que cero.");

        if (idDestino <= 0)
            throw new Exception("El ID del destino debe ser mayor que cero.");

        if (peso <= 0)
            throw new Exception("El peso debe ser mayor que cero.");

        if (alto <= 0)
            throw new Exception("El alto debe ser mayor que cero.");

        if (ancho <= 0)
            throw new Exception("El ancho debe ser mayor que cero.");

        if (largo <= 0)
            throw new Exception("El largo debe ser mayor que cero.");

        if (distancia <= 0)
            throw new Exception("La distancia debe ser mayor que cero.");

        if (string.IsNullOrWhiteSpace(modalidad))
            throw new Exception("La modalidad es obligatoria.");

        modalidad = modalidad.ToUpper();

        if (!estrategias.ContainsKey(modalidad))
            throw new Exception("La modalidad no es válida.");

        return repositorio.RegistrarEnvio(
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

    public bool ActualizarEnvio(
        int idEnvio,
        string modalidad,
        double pesoKg,
        double distanciaKm,
        string calle,
        string direccionPostal,
        string localidad)
    {
        if (idEnvio <= 0)
            throw new Exception("El ID del envío no es válido.");

        if (string.IsNullOrWhiteSpace(modalidad))
            throw new Exception("La modalidad es obligatoria.");

        modalidad = modalidad.ToUpper();

        if (!estrategias.ContainsKey(modalidad))
            throw new Exception("La modalidad no es válida.");

        if (pesoKg <= 0)
            throw new Exception("El peso debe ser mayor que cero.");

        if (distanciaKm <= 0)
            throw new Exception("La distancia debe ser mayor que cero.");

        if (string.IsNullOrWhiteSpace(calle))
            throw new Exception("La calle es obligatoria.");

        if (string.IsNullOrWhiteSpace(direccionPostal))
            throw new Exception("El código postal es obligatorio.");

        if (string.IsNullOrWhiteSpace(localidad))
            throw new Exception("La localidad es obligatoria.");

        return repositorio.ActualizarEnvio(
            idEnvio,
            modalidad,
            pesoKg,
            distanciaKm,
            calle,
            direccionPostal,
            localidad
        );
    }

    public IEnumerable<DatosEnvio> ListarEnvios()
    {
        return repositorio.ListarEnvios();
    }

    public IEnumerable<string> ObtenerHistorialEstado(int idEnvio)
    {
        if (idEnvio <= 0)
            throw new Exception("El ID del envío debe ser mayor que cero.");

        return repositorio.ObtenerHistorialEstado(idEnvio);
    }

    public IEnumerable<string> ObtenerEstadisticas(
        DateTime fechaDesde,
        DateTime fechaHasta)
    {
        if (fechaDesde > fechaHasta)
            throw new Exception("La fecha desde no puede ser mayor que la fecha hasta.");

        return repositorio.ObtenerEstadisticas(
            fechaDesde,
            fechaHasta
        );
    }

    public string? ObtenerEnvioPorId(int idEnvio)
    {
        if (idEnvio <= 0)
            throw new Exception("El ID del envío no es válido.");

        return repositorio.ObtenerEnvioPorId(idEnvio);
    }

    public CotizacionEnvio? ObtenerCotizacion(int idEnvio)
    {
        if (idEnvio <= 0)
            throw new Exception("El ID del envío no es válido.");

        DatosCotizacion? datos = repositorio.ObtenerDatosCotizacion(idEnvio);

        if (datos == null)
            return null;

        if (!estrategias.TryGetValue(datos.Modalidad, out var estrategia))
            throw new Exception("No existe una estrategia para esta modalidad.");

        double costo = estrategia.CalcularCosto(
            (double)datos.PesoKg,
            (double)datos.DistanciaKm
        );

        int dias = estrategia.CalcularDiasEstimados();

        return new CotizacionEnvio(
            datos.Modalidad,
            costo,
            dias
        );
    }
}

public record CotizacionEnvio(
    string Modalidad,
    double Costo,
    int DiasEstimados
);
