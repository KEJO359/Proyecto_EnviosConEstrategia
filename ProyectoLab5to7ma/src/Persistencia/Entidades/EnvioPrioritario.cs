using Aplicacion.Interfaces;
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

    public string ProcesarEnvio()
    {
        return "Procesando envio |Prioritario|";
    }
    public override string Modalidad
    {
        get { return "PRIORITARIO"; }
    }
}