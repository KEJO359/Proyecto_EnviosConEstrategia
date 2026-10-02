using Aplicacion.Interfaces;
using Aplicacion.Servicios;

namespace Tests;

public class TestEnvio
{
    [Fact]
    public void CambiarEstado_IdInvalido_LanzaExcepcion()
    {
        IEnvioRepository repositorio = new RepositorioFalso();
        ServicioEnvio servicio = new ServicioEnvio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.CambiarEstado(0, "EN_PROCESO"));
    }

    [Fact]
    public void CambiarEstado_EstadoVacio_LanzaExcepcion()
    {
        IEnvioRepository repositorio = new RepositorioFalso();
        ServicioEnvio servicio = new ServicioEnvio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.CambiarEstado(1, ""));
    }

    [Fact]
    public void CambiarEstado_EstadoInvalido_LanzaExcepcion()
    {
        IEnvioRepository repositorio = new RepositorioFalso();
        ServicioEnvio servicio = new ServicioEnvio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.CambiarEstado(1, "DETENIDO"));
    }

    [Fact]
    public void CambiarEstado_PendienteAEntregado_LanzaExcepcion()
    {
        IEnvioRepository repositorio = new RepositorioFalso();
        ServicioEnvio servicio = new ServicioEnvio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.CambiarEstado(1, "ENTREGADO"));
    }

    [Fact]
    public void CambiarEstado_PendienteAEnProceso_NoLanzaExcepcion()
    {
        IEnvioRepository repositorio = new RepositorioFalso();
        ServicioEnvio servicio = new ServicioEnvio(repositorio);

        servicio.CambiarEstado(1, "EN_PROCESO");
    }

    [Fact]
    public void Cancelar_IdInvalido_LanzaExcepcion()
    {
        IEnvioRepository repositorio = new RepositorioFalso();
        ServicioEnvio servicio = new ServicioEnvio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.Cancelar(0));
    }

    [Fact]
    public void Cancelar_EnvioEntregado_LanzaExcepcion()
    {
        IEnvioRepository repositorio = new RepositorioFalso();
        ServicioEnvio servicio = new ServicioEnvio(repositorio);

        repositorio.CambiarEstado(1, "EN_PROCESO");
        repositorio.CambiarEstado(1, "ENTREGADO");

        Assert.Throws<Exception>(() =>
            servicio.Cancelar(1));
    }

    [Fact]
    public void RegistrarEnvio_ClienteInvalido_LanzaExcepcion()
    {
        IEnvioRepository repositorio = new RepositorioFalso();
        ServicioEnvio servicio = new ServicioEnvio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.RegistrarEnvio(
                0,
                1,
                2,
                5,
                10,
                10,
                10,
                20,
                "ESTANDAR"));
    }

    [Fact]
    public void RegistrarEnvio_DireccionOrigenInvalida_LanzaExcepcion()
    {
        IEnvioRepository repositorio = new RepositorioFalso();
        ServicioEnvio servicio = new ServicioEnvio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.RegistrarEnvio(
                1,
                0,
                2,
                5,
                10,
                10,
                10,
                20,
                "ESTANDAR"));
    }

    [Fact]
    public void RegistrarEnvio_DireccionDestinoInvalida_LanzaExcepcion()
    {
        IEnvioRepository repositorio = new RepositorioFalso();
        ServicioEnvio servicio = new ServicioEnvio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.RegistrarEnvio(
                1,
                1,
                0,
                5,
                10,
                10,
                10,
                20,
                "ESTANDAR"));
    }

    [Fact]
    public void RegistrarEnvio_PesoInvalido_LanzaExcepcion()
    {
        IEnvioRepository repositorio = new RepositorioFalso();
        ServicioEnvio servicio = new ServicioEnvio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.RegistrarEnvio(
                1,
                1,
                2,
                0,
                10,
                10,
                10,
                20,
                "ESTANDAR"));
    }

    [Fact]
    public void RegistrarEnvio_DimensionesInvalidas_LanzaExcepcion()
    {
        IEnvioRepository repositorio = new RepositorioFalso();
        ServicioEnvio servicio = new ServicioEnvio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.RegistrarEnvio(
                1,
                1,
                2,
                5,
                0,
                10,
                10,
                20,
                "ESTANDAR"));
    }

    [Fact]
    public void RegistrarEnvio_DistanciaInvalida_LanzaExcepcion()
    {
        IEnvioRepository repositorio = new RepositorioFalso();
        ServicioEnvio servicio = new ServicioEnvio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.RegistrarEnvio(
                1,
                1,
                2,
                5,
                10,
                10,
                10,
                0,
                "ESTANDAR"));
    }

    [Fact]
    public void RegistrarEnvio_ModalidadVacia_LanzaExcepcion()
    {
        IEnvioRepository repositorio = new RepositorioFalso();
        ServicioEnvio servicio = new ServicioEnvio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.RegistrarEnvio(
                1,
                1,
                2,
                5,
                10,
                10,
                10,
                20,
                ""));
    }

    [Fact]
    public void RegistrarEnvio_ModalidadInvalida_LanzaExcepcion()
    {
        IEnvioRepository repositorio = new RepositorioFalso();
        ServicioEnvio servicio = new ServicioEnvio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.RegistrarEnvio(
                1,
                1,
                2,
                5,
                10,
                10,
                10,
                20,
                "RAPIDO"));
    }

    [Fact]
    public void ListarEnvios_DevuelveEnvios()
    {
        RepositorioFalso repositorio = new RepositorioFalso();
        ServicioEnvio servicio = new ServicioEnvio(repositorio);

        IEnumerable<string> envios = servicio.ListarEnvios();

        Assert.NotEmpty(envios);
    }

    [Fact]
    public void ObtenerHistorialEstado_IdInvalido_LanzaExcepcion()
    {
        RepositorioFalso repositorio = new RepositorioFalso();
        ServicioEnvio servicio = new ServicioEnvio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.ObtenerHistorialEstado(0));
    }

    [Fact]
    public void ObtenerHistorialEstado_DevuelveHistorial()
    {
        RepositorioFalso repositorio = new RepositorioFalso();
        ServicioEnvio servicio = new ServicioEnvio(repositorio);

        IEnumerable<string> historial =
            servicio.ObtenerHistorialEstado(1);

        Assert.NotEmpty(historial);
    }

    [Fact]
    public void ObtenerEstadisticas_DevuelveEstadisticas()
    {
        RepositorioFalso repositorio = new RepositorioFalso();
        ServicioEnvio servicio = new ServicioEnvio(repositorio);

        IEnumerable<string> estadisticas =
            servicio.ObtenerEstadisticas(
                new DateTime(2026, 1, 1),
                new DateTime(2026, 12, 31));

        Assert.NotEmpty(estadisticas);
    }

    [Fact]
    public void ObtenerEstadisticas_FechaInvalida_LanzaExcepcion()
    {
        RepositorioFalso repositorio = new RepositorioFalso();
        ServicioEnvio servicio = new ServicioEnvio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.ObtenerEstadisticas(
                new DateTime(2026, 12, 31),
                new DateTime(2026, 1, 1)));
    }
}

public class RepositorioFalso : IEnvioRepository
{
    private string estado = "PENDIENTE";

    public void CambiarEstado(int idEnvio, string nuevoEstado)
    {
        estado = nuevoEstado;
    }

    public void Cancelar(int idEnvio)
    {
        estado = "CANCELADO";
    }

    public string ObtenerEstado(int idEnvio)
    {
        return estado;
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
    }

    public IEnumerable<string> ListarEnvios()
    {
        return new List<string>
        {
            "Envio 1",
            "Envio 2"
        };
    }

    public IEnumerable<string> ObtenerHistorialEstado(int idEnvio)
    {
        return new List<string>
        {
            "PENDIENTE",
            "EN_PROCESO",
            "ENTREGADO"
        };
    }

    public IEnumerable<string> ObtenerEstadisticas(
        DateTime fechaDesde,
        DateTime fechaHasta)
    {
        return new List<string>
        {
            "Modalidad: ESTANDAR | Cantidad: 2 | Costo acumulado: 200 | Costo promedio: 100",
            "Modalidad: EXPRESS | Cantidad: 1 | Costo acumulado: 200 | Costo promedio: 200"
        };
    }
}