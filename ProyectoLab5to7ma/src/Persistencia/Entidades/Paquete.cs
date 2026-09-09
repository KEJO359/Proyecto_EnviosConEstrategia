namespace Persistencia.Entidades;

public class Paquete
{
    private double peso;
    private int altura;
    private int ancho;
    private int largo;

    public double Peso
    {
        get { return peso; }
        set
        {
            if (value <= 0)
            {
                throw new Exception("El peso debe ser mayor que cero.");
            }
                peso = value;
        }
    }

    public int Altura
    {
        get { return altura; }
        set
        {
            if (value <= 0)
            {
                throw new Exception("La altura debe ser mayor que cero.");
            }
                altura = value;
        }
    }

    public int Ancho
    {
        get { return ancho; }
        set
        {
            if (value <= 0)
            {
                throw new Exception("El ancho debe ser mayor que cero.");
            }
                ancho = value;
        }
    }

    public int Largo
    {
        get { return largo; }
        set
        {
            if (value <= 0)
            {
                throw new Exception("El largo debe ser mayor que cero.");
            }
                largo = value;
        }
    }

    public Paquete(double peso, int altura, int ancho, int largo)
    {
        Peso = peso;
        Altura = altura;
        Ancho = ancho;
        Largo = largo;
    }
}