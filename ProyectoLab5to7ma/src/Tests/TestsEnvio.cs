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
}