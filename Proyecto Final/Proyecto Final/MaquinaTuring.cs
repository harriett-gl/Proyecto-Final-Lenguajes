namespace Proyecto_Final;
using System;
using System.Collections.Generic;

public class MaquinaTuring
{
    private AFD afd;

    public MaquinaTuring()
    {
        afd = new AFD();
    }

    public void ProcesarCadena(string cadena)
    {
        Console.WriteLine("Procesando: " + cadena);

        // Información de la máquina
        MostrarInformacionMaquina(cadena);

        // Inicializar el árbol de derivación
        Node root = new Node("q0");

        // Verificar la cadena con el autómata
        bool esValida = afd.VerificarCadena(cadena, root);

        // Mostrar resultados
        Console.WriteLine("\nÁrbol de derivación:");
        PrintTree(root, "", true);

        Console.WriteLine("\nTabla de transición:");
        afd.PrintTransitionTable();


        if (esValida)
            Console.WriteLine("\nLa cadena válida.");
        else
            Console.WriteLine("\nLa cadena inválida.");

        Console.WriteLine(new string('-', 50));
    }

    private void MostrarInformacionMaquina(string cadena)
    {
        char[] alfabeto = { 'a', 'b', '*', '#' };
        string[] estados = { "q0", "q1", "q2", "q3", "q4" };

        Console.WriteLine("");
        Console.WriteLine("Alfabeto de la máquina de Turing: " + string.Join(", ", alfabeto));
        Console.WriteLine("Estados de la máquina de Turing: " + string.Join(", ", estados));

        // Separar la cadena en pares e impares
        List<char> pares = new List<char>();
        List<char> impares = new List<char>();
        for (int i = 0; i < cadena.Length; i++)
        {
            if (i % 2 == 0)
                pares.Add(cadena[i]);
            else
                impares.Add(cadena[i]);
        }
        Console.WriteLine("");
        Console.WriteLine("Cadena de caracteres pares: " + string.Join("", pares));
        Console.WriteLine("Cadena de caracteres impares: " + string.Join("", impares));

        // Mostrar la cadena en ambas direcciones
        DosCintas dosCintas = new DosCintas(cadena);
        dosCintas.MostrarCintas();

        // Mostrar simbología de la máquina
        MostrarSimbolosMaquina();
    }

    private void MostrarSimbolosMaquina()
    {
        Console.WriteLine("");
        Console.WriteLine("Simbología de la Máquina de Turing:");
        Console.WriteLine("M = (Q, Σ, δ, q0, F)");
        Console.WriteLine("Q = {q0, q1, q2, q3, q4}");
        Console.WriteLine("Σ = {a, b, *, #}");
        Console.WriteLine("q0 = Estado inicial");
        Console.WriteLine("F = {q4} (Estado de aceptación)");

    }

    private void PrintTree(Node node, string indent, bool last)
    {
        Console.Write(indent);
        if (last)
        {
            Console.Write("└─");
            indent += "  ";
        }
        else
        {
            Console.Write("├─");
            indent += "| ";
        }
        Console.WriteLine(node.Value);

        for (int i = 0; i < node.Children.Count; i++)
        {
            PrintTree(node.Children[i], indent, i == node.Children.Count - 1);
        }
    }
}