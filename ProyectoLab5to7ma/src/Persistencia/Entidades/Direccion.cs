namespace Persistencia.Entidades;

public class Direccion
{
    public int IdDireccion { get; set; }

    public string Calle { get; set; }

    public string DireccionPostal { get; set; }

    public string Localidad { get; set; }

    public Direccion(string calle, string direccionPostal, string localidad)
    {
        Calle = calle;
        DireccionPostal = direccionPostal;
        Localidad = localidad;
    }
}