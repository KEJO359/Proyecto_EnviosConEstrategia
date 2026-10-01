namespace Aplicacion.Servicios;

public class ServicioPaquete
{
    public void ValidarPaquete(
        double peso,
        int altura,
        int ancho,
        int largo)
    {
        if (peso <= 0)
        {
            throw new Exception("El peso debe ser mayor que cero.");
        }

        if (altura <= 0)
        {
            throw new Exception("La altura debe ser mayor que cero.");
        }

        if (ancho <= 0)
        {
            throw new Exception("El ancho debe ser mayor que cero.");
        }

        if (largo <= 0)
        {
            throw new Exception("El largo debe ser mayor que cero.");
        }
    }
}