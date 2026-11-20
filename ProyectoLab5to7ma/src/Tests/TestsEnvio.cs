
using Aplicacion.Interfaces;
using Aplicacion.Servicios;
using Persistencia.Entidades;

namespace Tests;

public class TestEnvio
{
    private ServicioEnvio CrearServicio(RepositorioFalso repositorio)
    {
        IEnumerable<IEstrategiaCotizacion> estrategias = new List<IEstrategiaCotizacion>
        {
            new EstrategiaEstandar(),
            new EstrategiaExpress(),
            new EstrategiaPrioritaria()
        };

        return new ServicioEnvio(repositorio, estrategias);
    }

    [Fact]
    public void CambiarEstado_IdInvalido_LanzaExcepcion()
    {
        var repositorio = new RepositorioFalso();
        var servicio = CrearServicio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.CambiarEstado(0, "DESPACHADO"));
    }

    [Fact]
    public void CambiarEstado_EstadoVacio_LanzaExcepcion()
    {
        var repositorio = new RepositorioFalso();
        var servicio = CrearServicio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.CambiarEstado(1, ""));
    }

    [Fact]
    public void CambiarEstado_EstadoInvalido_LanzaExcepcion()
    {
        var repositorio = new RepositorioFalso();
        var servicio = CrearServicio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.CambiarEstado(1, "DETENIDO"));
    }

    [Fact]
    public void CambiarEstado_PendienteAEntregado_LanzaExcepcion()
    {
        var repositorio = new RepositorioFalso();
        var servicio = CrearServicio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.CambiarEstado(1, "ENTREGADO"));
    }

    [Fact]
    public void CambiarEstado_PendienteADespachado_NoLanzaExcepcion()
    {
        var repositorio = new RepositorioFalso();
        var servicio = CrearServicio(repositorio);

        servicio.CambiarEstado(1, "DESPACHADO");

        Assert.Equal("DESPACHADO", repositorio.ObtenerEstado(1));
    }

    [Fact]
    public void CambiarEstado_DespachadoAEntregado_NoLanzaExcepcion()
    {
        var repositorio = new RepositorioFalso();
        var servicio = CrearServicio(repositorio);

        repositorio.CambiarEstado(1, "DESPACHADO");

        servicio.CambiarEstado(1, "ENTREGADO");

        Assert.Equal("ENTREGADO", repositorio.ObtenerEstado(1));
    }

    [Fact]
    public void CambiarEstado_DespachadoAPendiente_LanzaExcepcion()
    {
        var repositorio = new RepositorioFalso();
        var servicio = CrearServicio(repositorio);

        repositorio.CambiarEstado(1, "DESPACHADO");

        Assert.Throws<Exception>(() =>
            servicio.CambiarEstado(1, "PENDIENTE"));
    }

    [Fact]
    public void Cancelar_IdInvalido_LanzaExcepcion()
    {
        var repositorio = new RepositorioFalso();
        var servicio = CrearServicio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.Cancelar(0));
    }

    [Fact]
    public void Cancelar_EnvioEntregado_LanzaExcepcion()
    {
        var repositorio = new RepositorioFalso();
        var servicio = CrearServicio(repositorio);

        repositorio.CambiarEstado(1, "DESPACHADO");
        repositorio.CambiarEstado(1, "ENTREGADO");

        Assert.Throws<Exception>(() =>
            servicio.Cancelar(1));
    }

    [Fact]
    public void RegistrarEnvio_ClienteInvalido_LanzaExcepcion()
    {
        var repositorio = new RepositorioFalso();
        var servicio = CrearServicio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.RegistrarEnvio(
                0, 1, 2, 5, 10, 10, 10, 20, "ESTANDAR"));
    }

    [Fact]
    public void RegistrarEnvio_DireccionOrigenInvalida_LanzaExcepcion()
    {
        var repositorio = new RepositorioFalso();
        var servicio = CrearServicio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.RegistrarEnvio(
                1, 0, 2, 5, 10, 10, 10, 20, "ESTANDAR"));
    }

    [Fact]
    public void RegistrarEnvio_DireccionDestinoInvalida_LanzaExcepcion()
    {
        var repositorio = new RepositorioFalso();
        var servicio = CrearServicio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.RegistrarEnvio(
                1, 1, 0, 5, 10, 10, 10, 20, "ESTANDAR"));
    }

    [Fact]
    public void RegistrarEnvio_PesoInvalido_LanzaExcepcion()
    {
        var repositorio = new RepositorioFalso();
        var servicio = CrearServicio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.RegistrarEnvio(
                1, 1, 2, 0, 10, 10, 10, 20, "ESTANDAR"));
    }

    [Fact]
    public void RegistrarEnvio_DimensionesInvalidas_LanzaExcepcion()
    {
        var repositorio = new RepositorioFalso();
        var servicio = CrearServicio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.RegistrarEnvio(
                1, 1, 2, 5, 0, 10, 10, 20, "ESTANDAR"));
    }

    [Fact]
    public void RegistrarEnvio_DistanciaInvalida_LanzaExcepcion()
    {
        var repositorio = new RepositorioFalso();
        var servicio = CrearServicio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.RegistrarEnvio(
                1, 1, 2, 5, 10, 10, 10, 0, "ESTANDAR"));
    }

    [Fact]
    public void RegistrarEnvio_ModalidadVacia_LanzaExcepcion()
    {
        var repositorio = new RepositorioFalso();
        var servicio = CrearServicio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.RegistrarEnvio(
                1, 1, 2, 5, 10, 10, 10, 20, ""));
    }

    [Fact]
    public void RegistrarEnvio_ModalidadInvalida_LanzaExcepcion()
    {
        var repositorio = new RepositorioFalso();
        var servicio = CrearServicio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.RegistrarEnvio(
                1, 1, 2, 5, 10, 10, 10, 20, "RAPIDO"));
    }

    [Fact]
    public void ListarEnvios_DevuelveEnvios()
    {
        var repositorio = new RepositorioFalso();
        var servicio = CrearServicio(repositorio);

        IEnumerable<DatosEnvio> envios = servicio.ListarEnvios();

        Assert.NotEmpty(envios);
    }

    [Fact]
    public void ObtenerHistorialEstado_IdInvalido_LanzaExcepcion()
    {
        var repositorio = new RepositorioFalso();
        var servicio = CrearServicio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.ObtenerHistorialEstado(0));
    }

    [Fact]
    public void ObtenerHistorialEstado_DevuelveHistorial()
    {
        var repositorio = new RepositorioFalso();
        var servicio = CrearServicio(repositorio);

        IEnumerable<string> historial =
            servicio.ObtenerHistorialEstado(1);

        Assert.NotEmpty(historial);
    }

    [Fact]
    public void ObtenerEstadisticas_DevuelveEstadisticas()
    {
        var repositorio = new RepositorioFalso();
        var servicio = CrearServicio(repositorio);

        IEnumerable<string> estadisticas =
            servicio.ObtenerEstadisticas(
                new DateTime(2026, 1, 1),
                new DateTime(2026, 12, 31));

        Assert.NotEmpty(estadisticas);
    }

    [Fact]
    public void ObtenerEstadisticas_FechaInvalida_LanzaExcepcion()
    {
        var repositorio = new RepositorioFalso();
        var servicio = CrearServicio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.ObtenerEstadisticas(
                new DateTime(2026, 12, 31),
                new DateTime(2026, 1, 1)));
    }

    [Fact]
    public void EnvioEstandar_CalcularCosto_DevuelveCostoCorrecto()
    {
        Envio envio = CrearEnvioEstandar();

        Assert.Equal(2100, envio.CalcularCosto());
    }

    [Fact]
    public void EnvioExpress_CalcularCosto_DevuelveCostoCorrecto()
    {
        Envio envio = CrearEnvioExpress();

        Assert.Equal(3950, envio.CalcularCosto());
    }

    [Fact]
    public void EnvioPrioritario_CalcularCosto_DevuelveCostoCorrecto()
    {
        Envio envio = CrearEnvioPrioritario();

        Assert.Equal(5800, envio.CalcularCosto());
    }

    [Fact]
    public void EnvioEstandar_CalcularTiempo_DevuelveTiempoCorrecto()
    {
        Envio envio = CrearEnvioEstandar();

        Assert.Equal(5, envio.CalcularTiempoEntrega());
    }

    [Fact]
    public void EnvioExpress_CalcularTiempo_DevuelveTiempoCorrecto()
    {
        Envio envio = CrearEnvioExpress();

        Assert.Equal(2, envio.CalcularTiempoEntrega());
    }

    [Fact]
    public void EnvioPrioritario_CalcularTiempo_DevuelveTiempoCorrecto()
    {
        Envio envio = CrearEnvioPrioritario();

        Assert.Equal(1, envio.CalcularTiempoEntrega());
    }

    [Fact]
    public void ObtenerCotizacion_Estandar_DevuelveCostoYTiempoCorrectos()
    {
        var repositorio = new RepositorioFalso();
        var servicio = CrearServicio(repositorio);

        var cotizacion = servicio.ObtenerCotizacion(1);

        Assert.NotNull(cotizacion);
        Assert.Equal("ESTANDAR", cotizacion.Modalidad);
        Assert.Equal(2100, cotizacion.Costo);
        Assert.Equal(5, cotizacion.DiasEstimados);
    }

    [Fact]
    public void ObtenerCotizacion_IdInvalido_LanzaExcepcion()
    {
        var repositorio = new RepositorioFalso();
        var servicio = CrearServicio(repositorio);

        Assert.Throws<Exception>(() =>
            servicio.ObtenerCotizacion(0));
    }

    private EnvioEstandar CrearEnvioEstandar()
    {
        Cliente cliente = new Cliente(
            "Juan", "Perez", 12345678,
            "1111111111", "juan@gmail.com");

        Direccion origen = new Direccion(
            "Calle 1", "1704", "San Justo");

        Direccion destino = new Direccion(
            "Calle 2", "1704", "Ramos Mejia");

        Paquete paquete = new Paquete(5, 10, 10, 10);

        return new EnvioEstandar(
            1, cliente, origen, destino, 10, paquete);
    }

    private EnvioExpress CrearEnvioExpress()
    {
        Cliente cliente = new Cliente(
            "Juan", "Perez", 12345678,
            "1111111111", "juan@gmail.com");

        Direccion origen = new Direccion(
            "Calle 1", "1704", "San Justo");

        Direccion destino = new Direccion(
            "Calle 2", "1704", "Ramos Mejia");

        Paquete paquete = new Paquete(5, 10, 10, 10);

        return new EnvioExpress(
            1, cliente, origen, destino, 10, paquete);
    }

    private EnvioPrioritario CrearEnvioPrioritario()
    {
        Cliente cliente = new Cliente(
            "Juan", "Perez", 12345678,
            "1111111111", "juan@gmail.com");

        Direccion origen = new Direccion(
            "Calle 1", "1704", "San Justo");

        Direccion destino = new Direccion(
            "Calle 2", "1704", "Ramos Mejia");

        Paquete paquete = new Paquete(5, 10, 10, 10);

        return new EnvioPrioritario(
            1, cliente, origen, destino, 10, paquete);
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
        return 1;
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
        return idEnvio == 1;
    }

    public IEnumerable<DatosEnvio> ListarEnvios()
    {
        return new List<DatosEnvio>
        {
            new DatosEnvio(
                1, 2, 1, 1, 2, 20,
                "ESTANDAR", "PENDIENTE",
                new DateTime(2026, 11, 19)
            ),
            new DatosEnvio(
                2, 2, 2, 1, 2, 30,
                "EXPRESS", "DESPACHADO",
                new DateTime(2026, 11, 19)
            )
        };
    }

    public IEnumerable<string> ObtenerHistorialEstado(int idEnvio)
    {
        return new List<string>
        {
            "PENDIENTE",
            "DESPACHADO",
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

    public string? ObtenerEnvioPorId(int idEnvio)
    {
        return null;
    }

    public DatosCotizacion? ObtenerDatosCotizacion(int idEnvio)
    {
        return new DatosCotizacion("ESTANDAR", 5, 10);
    }
}
