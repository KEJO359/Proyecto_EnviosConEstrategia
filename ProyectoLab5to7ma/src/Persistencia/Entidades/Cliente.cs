namespace Persistencia.Entidades;

public class Cliente
{
    private string nombre  = null!;
    private string apellido = null!;
    private int dni;
    private string telefono = null!;
    private string email = null!;

    public string Nombre
    {
        get { return nombre; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("El nombre es obligatorio.");
            }
                nombre = value;
        }
    }

    public string Apellido
    {
        get { return apellido; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("El apellido es obligatorio.");
            }
                apellido = value;
        }
    }

    public int Dni
    {
        get { return dni; }
        set
        {
            if (value <= 0)
            {
                throw new Exception("El DNI debe ser mayor que cero.");
            }
                dni = value;
        }
    }

    public string Telefono
    {
        get { return telefono; }
        set
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new Exception ("El numero telefonico es obligatorio");
            }
                telefono = value;
        }
    }

    public string Email
    {
        get { return email; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception("El email es obligatorio.");
            }
                email = value;
        } 
    }

    public Cliente(string nombre, string apellido, int dni, string telefono, string email)
    {
        Nombre = nombre;
        Apellido = apellido;
        Dni = dni;
        Telefono = telefono;
        Email = email;
    }
}