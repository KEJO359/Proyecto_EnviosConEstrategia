namespace Persistencia.Entidades;

public class EnvioEstandar : Envio , IServicioEnvio
{
    public EnvioEstandar(int idEnvio, Cliente cliente, Direccion origen,  Direccion destino, double distancia, Paquete paquete): base(idEnvio, cliente, origen, destino, distancia, paquete)
    {
    }

    public override double CalcularCosto()
    {
        return Distancia * 10;
    }

    public override int CalcularTiempoEntrega()
    {
        return 5;
    }

    public void ProcesarEnvio()
    {
        Console.WriteLine("Procesando envio |Estandar| lilbro");
    }
}