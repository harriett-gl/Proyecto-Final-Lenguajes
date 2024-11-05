namespace Proyecto_Final;
using System;
using System.Collections.Generic;

public class AFD
{
    private Dictionary<string, Dictionary<char, string>> tablaTransiciones;
    private Stack<string> pilaEstados;
    private Stack<char> pilaAceptados;
    private Stack<char> pilaErrores;

    public AFD()
    {
        tablaTransiciones = new Dictionary<string, Dictionary<char, string>>();
        pilaEstados = new Stack<string>();
        pilaAceptados = new Stack<char>();
        pilaErrores = new Stack<char>();

        // Definimos las transiciones del autómata
        InicializarTransiciones();
    }

    private void InicializarTransiciones()
    {
        // Aquí definimos las transiciones del autómata
        tablaTransiciones["q0"] = new Dictionary<char, string> { { 'a', "q1" } };
        tablaTransiciones["q1"] = new Dictionary<char, string> { { 'b', "q2" } };
        tablaTransiciones["q2"] = new Dictionary<char, string> { { 'a', "q3" } };
        tablaTransiciones["q3"] = new Dictionary<char, string>
        {
            { 'a', "q3" },
            { 'b', "q1" },
            { '*', "q4" }
        };
        tablaTransiciones["q4"] = new Dictionary<char, string>
        {
            { 'a', "q4" },
            { '*', "q4" },
            { '#', "q4" }
        };
    }

    public bool VerificarCadena(string cadena, Node root)
    {
        string estadoActual = "q0";
        Node currentNode = root;
        bool esValida = false;

        foreach (char caracter in cadena)
        {
            pilaEstados.Push(estadoActual);

            string estadoSiguiente = ObtenerSiguienteEstado(estadoActual, caracter);
            if (estadoSiguiente != null)
            {
                pilaAceptados.Push(caracter);
                Node nextNode = new Node(estadoSiguiente);
                currentNode.Children.Add(nextNode);
                currentNode = nextNode;

                estadoActual = estadoSiguiente;
            }
            else
            {
                pilaErrores.Push(caracter);
                Node errorNode = new Node($"Error ({caracter})");
                currentNode.Children.Add(errorNode);
                currentNode = errorNode;
                break;
            }

            if (estadoActual == "q4" && caracter == '#')
            {
                esValida = true;
            }
        }
        return esValida;
    }

    private string ObtenerSiguienteEstado(string estadoActual, char caracter)
    {
        if (tablaTransiciones.ContainsKey(estadoActual) &&
            tablaTransiciones[estadoActual].ContainsKey(caracter))
        {
            return tablaTransiciones[estadoActual][caracter];
        }
        return null;
    }

    public void PrintTransitionTable()
    {
        Console.WriteLine("      a     b     *     #");
        Console.WriteLine("    ------------------------");

        foreach (var estado in tablaTransiciones)
        {
            Console.Write($"{estado.Key}  ");
            foreach (var caracter in new[] { 'a', 'b', '*', '#' })
            {
                if (estado.Value.ContainsKey(caracter))
                {
                    Console.Write($"{estado.Value[caracter],-5} ");
                }
                else
                {
                    Console.Write($"{"-",-5} ");
                }
            }
            Console.WriteLine();
        }
    }

    public void LimpiarPilas()
    {
        pilaEstados.Clear();
        pilaAceptados.Clear();
        pilaErrores.Clear();
    }
}
