using Aplicacion.Interfaces;

namespace Persistencia.Entidades;

public class Cliente : INotificacion
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public int Dni { get; set; }

    public string Telefono { get; set; }

    public string Email { get; set; }

    public Cliente(string nombre, string apellido, int dni, string telefono, string email)
    {
        Nombre = nombre;
        Apellido = apellido;
        Dni = dni;
        Telefono = telefono;
        Email = email;
    }

   public void Enviar(string mensaje)
    {}
}