using Aplicacion.Interfaces;

namespace Persistencia.Entidades;

public abstract class Envio 
{
    private int idEnvio;
    private Cliente cliente = null!;
    private Direccion origen = null!;
    private Direccion destino = null!;
    private double distancia;

    public int IdEnvio
    {
        get { return idEnvio; }
        set
        {
            if (value <= 0)
            {
                throw new Exception("El ID debe ser mayor que cero.");
            }
                idEnvio = value;
        }
    }

    public Cliente Cliente
    {
        get { return cliente; }
        set
        {
            if (value == null)
            {
                throw new Exception("El cliente es obligatorio.");
            }
                cliente = value;
        }
    }

    public Direccion Origen
    {
        get { return origen; }
        set
        {
            if (value == null)
            {
                throw new Exception("El origen es obligatorio.");
            }
                origen = value;
        }
    }

    public Direccion Destino
    {
        get { return destino; }
        set
        {
            if (value == null)
            {
                throw new Exception("El destino es obligatorio.");
            }
                destino = value;
        }
    }

    public double Distancia
    {
        get { return distancia; }
        set
        {
            if (value <= 0)
            {
                throw new Exception("La distancia debe ser mayor que cero.");
            }
                distancia = value;
        }
    }

    public Paquete Paquete { get; set; }

    public Envio(int idEnvio, Cliente cliente, Direccion origen, Direccion destino, double distancia, Paquete paquete)
    {
        IdEnvio = idEnvio;
        Cliente = cliente;
        Origen = origen;
        Destino = destino;
        Distancia = distancia;
        Paquete = paquete;
    }

    public abstract double CalcularCosto();

    public abstract int CalcularTiempoEntrega();
    public void NotificarCliente()
    {
        Cliente.Enviar("Su envío fue procesado correctamente.");
    }
}