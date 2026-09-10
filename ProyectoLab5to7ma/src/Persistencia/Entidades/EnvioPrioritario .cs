namespace Persistencia.Entidades;

public class EnvioPrioritario : Envio , IServicioEnvio 
{
    public EnvioPrioritario(int idEnvio, Cliente cliente, Direccion origen, Direccion destino, double distancia, Paquete paquete): base(idEnvio, cliente, origen, destino, distancia, paquete)
    {
    }

    public override double CalcularCosto()
    {
        return Distancia * 30;
    }

    public override int CalcularTiempoEntrega()
    {
        return 1;
    }

    public void ProcesarEnvio()
    {
        Console.WriteLine("Procesando envio |Prioritario| lilbro");
    }
}