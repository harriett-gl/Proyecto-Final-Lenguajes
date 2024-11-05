namespace Proyecto_Final;
using System;

public class DosCintas
{
    public string Cinta1 { get; set; }
    public string Cinta2 { get; set; }

    public DosCintas(string cadena)
    {
        Cinta1 = cadena;
        char[] cadenaReversa = cadena.ToCharArray();
        Array.Reverse(cadenaReversa);
        Cinta2 = new string(cadenaReversa);
    }

    public void MostrarCintas()
    {
        Console.WriteLine("Cadena de derecha a izquierda: " + FormatearCadena(Cinta2));
        Console.WriteLine("Cadena de izquierda a derecha: " + FormatearCadena(Cinta1));
    }

    private string FormatearCadena(string cadena)
    {
        return cadena.Replace("#", " #").Replace("*", " *");
    }
}