namespace Persistencia.Entidades;

public abstract class Envio
{
    public int idEnvio {get;set;}
    public int altura {get;set;}
    public int ancho {get;set;}
    public int largo {get;set;}
    public string nombre {get;set;} = string.Empty;

    public Envio (int idEnvio, int altura, int ancho, int largo, string nombre)
    {
        this.idEnvio = idEnvio;
        this.altura = altura;
        this.ancho = ancho;
        this.largo = largo;
        this.nombre = nombre;
    }
}