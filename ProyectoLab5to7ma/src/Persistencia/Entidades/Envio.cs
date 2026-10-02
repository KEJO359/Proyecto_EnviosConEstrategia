using Aplicacion.Interfaces;

namespace Persistencia.Entidades;

public abstract class Envio
{
    public int IdEnvio { get; set; }

    public Cliente Cliente { get; set; } = null!;

    public Direccion Origen { get; set; } = null!;

    public Direccion Destino { get; set; } = null!;

    public double Distancia { get; set; }

    public Paquete Paquete { get; set; } = null!;

    public Envio(
        int idEnvio,
        Cliente cliente,
        Direccion origen,
        Direccion destino,
        double distancia,
        Paquete paquete)
    {
        IdEnvio = idEnvio;
        Cliente = cliente;
        Origen = origen;
        Destino = destino;
        Distancia = distancia;
        Paquete = paquete;
    }

    public abstract string Modalidad { get; }

    public abstract double CalcularCosto();

    public abstract int CalcularTiempoEntrega();

    public void NotificarCliente()
    {
        Cliente.Enviar("Su envío fue procesado correctamente.");
    }
}