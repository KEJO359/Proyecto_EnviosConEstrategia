using Aplicacion.Servicios;

namespace Tests;

public class TestPaquete
{
    [Fact]
    public void ValidarPaquete_PesoInvalido_LanzaExcepcion()
    {
        ServicioPaquete servicio = new ServicioPaquete();

        Assert.Throws<Exception>(() =>
            servicio.ValidarPaquete(
                0,
                10,
                10,
                10));
    }

    [Fact]
    public void ValidarPaquete_AlturaInvalida_LanzaExcepcion()
    {
        ServicioPaquete servicio = new ServicioPaquete();

        Assert.Throws<Exception>(() =>
            servicio.ValidarPaquete(
                5,
                0,
                10,
                10));
    }

    [Fact]
    public void ValidarPaquete_AnchoInvalido_LanzaExcepcion()
    {
        ServicioPaquete servicio = new ServicioPaquete();

        Assert.Throws<Exception>(() =>
            servicio.ValidarPaquete(
                5,
                10,
                0,
                10));
    }

    [Fact]
    public void ValidarPaquete_LargoInvalido_LanzaExcepcion()
    {
        ServicioPaquete servicio = new ServicioPaquete();

        Assert.Throws<Exception>(() =>
            servicio.ValidarPaquete(
                5,
                10,
                10,
                0));
    }
}