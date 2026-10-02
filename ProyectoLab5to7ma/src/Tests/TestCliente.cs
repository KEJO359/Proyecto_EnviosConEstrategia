using Aplicacion.Servicios;

namespace Tests;

public class TestCliente
{
    [Fact]
    public void ValidarCliente_NombreVacio_LanzaExcepcion()
    {
        ServicioCliente servicio = new ServicioCliente();

        Assert.Throws<Exception>(() =>
            servicio.ValidarCliente(
                "",
                "Jaime",
                12345678,
                "1122334455",
                "correo@gmail.com"));
    }

    [Fact]
    public void ValidarCliente_ApellidoVacio_LanzaExcepcion()
    {
        ServicioCliente servicio = new ServicioCliente();

        Assert.Throws<Exception>(() =>
            servicio.ValidarCliente(
                "Joaquin",
                "",
                12345678,
                "1122334455",
                "correo@gmail.com"));
    }

    [Fact]
    public void ValidarCliente_DniInvalido_LanzaExcepcion()
    {
        ServicioCliente servicio = new ServicioCliente();

        Assert.Throws<Exception>(() =>
            servicio.ValidarCliente(
                "Joaquin",
                "Jaime",
                0,
                "1122334455",
                "correo@gmail.com"));
    }

    [Fact]
    public void ValidarCliente_TelefonoVacio_LanzaExcepcion()
    {
        ServicioCliente servicio = new ServicioCliente();

        Assert.Throws<Exception>(() =>
            servicio.ValidarCliente(
                "Joaquin",
                "Jaime",
                12345678,
                "",
                "correo@gmail.com"));
    }

    [Fact]
    public void ValidarCliente_EmailVacio_LanzaExcepcion()
    {
        ServicioCliente servicio = new ServicioCliente();

        Assert.Throws<Exception>(() =>
            servicio.ValidarCliente(
                "Joaquin",
                "Jaime",
                12345678,
                "1122334455",
                ""));
    }
}