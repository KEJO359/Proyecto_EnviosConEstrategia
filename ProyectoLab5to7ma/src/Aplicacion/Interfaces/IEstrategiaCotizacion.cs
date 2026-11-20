
namespace Aplicacion.Interfaces;

public interface IEstrategiaCotizacion
{
    string Modalidad { get; }

    double CalcularCosto(double pesoKg, double distanciaKm);

    int CalcularDiasEstimados();
}
