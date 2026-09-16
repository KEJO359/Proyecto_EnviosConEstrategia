using Aplicacion.Interfaces;
namespace Persistencia.Entidades;

public class EnvioExpress : Envio , IServicioEnvio
{
    public EnvioExpress(int idEnvio, Cliente cliente, Direccion origen, Direccion destino, double distancia, Paquete paquete): base(idEnvio, cliente, origen, destino, distancia, paquete)
    {
    }

    public override double CalcularCosto()
    {
        return Distancia * 20;
    }

    public override int CalcularTiempoEntrega()
    {
        return 2;
    }
    
    public void ProcesarEnvio()
    {
        Console.WriteLine("Procesando envio |Express| lilbro");
    }
}