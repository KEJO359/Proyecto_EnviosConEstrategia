namespace Persistencia.Entidades
{
    public class Direccion
    {
        public string calle {get; set;} = string.Empty;
        public string direccionPostal {get; set;} = string.Empty;
        public string localidad {get;set;} = string.Empty;


        public Direccion (string calle, string direccionPostal, string localidad)
        {
            this.calle = calle;
            this.direccionPostal = direccionPostal;
            this.localidad = localidad;
        }
    }
}