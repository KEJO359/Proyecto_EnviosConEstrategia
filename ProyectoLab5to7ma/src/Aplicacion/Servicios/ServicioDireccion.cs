namespace Aplicacion.Servicios;

public class ServicioDireccion
{
    public void ValidarDireccion(
        string calle,
        string direccionPostal,
        string localidad)
    {
        if (string.IsNullOrWhiteSpace(calle))
        {
            throw new Exception("La calle es obligatoria.");
        }

        if (string.IsNullOrWhiteSpace(direccionPostal))
        {
            throw new Exception("La dirección postal es obligatoria.");
        }

        if (string.IsNullOrWhiteSpace(localidad))
        {
            throw new Exception("La localidad es obligatoria.");
        }
    }
}