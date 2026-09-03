namespace Persistencia.Entidades
{
    public class Cliente
    {
        public string nombre {get;set;} = string.Empty;
        public string apellido {get;set;} = string.Empty;
        public int dni {get;set;} 
        public string telefono {get;set;} = string.Empty;
        public string email {get;set;} = string.Empty;

        public Cliente(string nombre, string apellido, int dni, string telefono, string email)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.telefono = telefono;
            this.email = email;
        }
    }
}