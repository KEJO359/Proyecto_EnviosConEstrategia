using Aplicacion.Servicios;

namespace Tests;

public class TestDireccion
{
    [Fact]
    public void ValidarDireccion_CalleVacia_LanzaExcepcion()
    {
        ServicioDireccion servicio = new ServicioDireccion();

        Assert.Throws<Exception>(() =>
            servicio.ValidarDireccion(
                "",
                "1000",
                "Buenos Aires"));
    }

    [Fact]
    public void ValidarDireccion_DireccionPostalVacia_LanzaExcepcion()
    {
        ServicioDireccion servicio = new ServicioDireccion();

        Assert.Throws<Exception>(() =>
            servicio.ValidarDireccion(
                "Av. Siempre Viva 123",
                "",
                "Buenos Aires"));
    }

    [Fact]
    public void ValidarDireccion_LocalidadVacia_LanzaExcepcion()
    {
        ServicioDireccion servicio = new ServicioDireccion();

        Assert.Throws<Exception>(() =>
            servicio.ValidarDireccion(
                "Av. Siempre Viva 123",
                "1000",
                ""));
    }
}