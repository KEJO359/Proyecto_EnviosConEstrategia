
using Aplicacion.Interfaces;

namespace Aplicacion.Servicios;

public class EstrategiaEstandar : IEstrategiaCotizacion
{
    public string Modalidad => "ESTANDAR";

    public double CalcularCosto(double pesoKg, double distanciaKm)
    {
        return 1000 + (pesoKg * 200) + (distanciaKm * 10);
    }

    public int CalcularDiasEstimados()
    {
        return 5;
    }
}

public class EstrategiaExpress : IEstrategiaCotizacion
{
    public string Modalidad => "EXPRESS";

    public double CalcularCosto(double pesoKg, double distanciaKm)
    {
        return 2000 + (pesoKg * 350) + (distanciaKm * 20);
    }

    public int CalcularDiasEstimados()
    {
        return 2;
    }
}

public class EstrategiaPrioritaria : IEstrategiaCotizacion
{
    public string Modalidad => "PRIORITARIO";

    public double CalcularCosto(double pesoKg, double distanciaKm)
    {
        return 3000 + (pesoKg * 500) + (distanciaKm * 30);
    }

    public int CalcularDiasEstimados()
    {
        return 1;
    }
}
