namespace Proyecto_Final;
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "/Users/harriett/Downloads/CadenasProyectoFinalLenguaje.txt";

        try
        {
            string[] cadenas = File.ReadAllLines(filePath);
            if (cadenas.Length < 10)
            {
                Console.WriteLine("¡Atención! EL archivo debe tener 10 cadenas.");
                return;
            }

            MaquinaTuring maquina = new MaquinaTuring();

            foreach (string cadena in cadenas)
            {
                string trimmedCadena = cadena.Trim();
                if (!string.IsNullOrEmpty(trimmedCadena)) // Asegúrate de que no esté vacía
                {
                    maquina.ProcesarCadena(trimmedCadena);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Archivo no disponible: {ex.Message}");
        }
    }
}