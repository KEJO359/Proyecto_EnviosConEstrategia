namespace Aplicacion.Servicios;

public class ServicioCliente
{
    public void ValidarCliente(
        string nombre,
        string apellido,
        int dni,
        string telefono,
        string email)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new Exception("El nombre es obligatorio.");
        }

        if (string.IsNullOrWhiteSpace(apellido))
        {
            throw new Exception("El apellido es obligatorio.");
        }

        if (dni <= 0)
        {
            throw new Exception("El DNI debe ser mayor que cero.");
        }

        if (string.IsNullOrWhiteSpace(telefono))
        {
            throw new Exception("El número telefónico es obligatorio.");
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            throw new Exception("El email es obligatorio.");
        }
    }
}