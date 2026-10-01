namespace Persistencia.Entidades;

public class Paquete
{
    public int IdPaquete { get; set; }

    public double Peso { get; set; }

    public int Altura { get; set; }

    public int Ancho { get; set; }

    public int Largo { get; set; }

    public Paquete(double peso, int altura, int ancho, int largo)
    {
        Peso = peso;
        Altura = altura;
        Ancho = ancho;
        Largo = largo;
    }
}