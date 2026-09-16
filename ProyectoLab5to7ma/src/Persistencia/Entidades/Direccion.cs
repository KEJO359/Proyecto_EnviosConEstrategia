namespace Persistencia.Entidades;

public class Direccion
{
    private string calle = null!;
    private string direccionPostal = null!;
    private string localidad = null!;

    public string Calle
    {
        get { return calle; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception("La calle es obligatoria.");
            }
                calle = value;
        }
    }

    public string DireccionPostal
    {
        get { return direccionPostal; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception("La dirección postal es obligatoria.");
            }
                direccionPostal = value;
        }
    }

    public string Localidad
    {
        get { return localidad; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception("La localidad es obligatoria.");
            }
                localidad = value;
        }
    }

    public Direccion(string calle, string direccionPostal, string localidad)
    {
        Calle = calle;
        DireccionPostal = direccionPostal;
        Localidad = localidad;
    }
}