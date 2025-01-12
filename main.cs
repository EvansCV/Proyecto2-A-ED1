// Proyecto Music Box para Datos 1.
// Fecha de Creación: 10 de enero de 2025.
// Autores: Evans Corrales Valverde y Alex Feng Wu.

namespace Proyecto2
{
    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;

    class Program
    { 
        public static void Main(string[] args) {
        
            // Texto de presentación
            Console.WriteLine("Ingrese sus partituras utilizando el siguiente formato:\n");
            Console.WriteLine("(NOTA 1, FIGURA 1), (NOTA 2, FIGURA 2), ... (NOTA n, FIGURA n)\n");
            Console.WriteLine("Por ejemplo\n");
            Console.WriteLine("(Do, negra), (Re, blanca), (La, Semicorchea)\n");
            Console.WriteLine(@"Si desea salir, escriba ""Salir"" ");
            
            while (true)
            {
                Console.Write("Sus notas: ");
                string notas = Console.ReadLine();

                // Salida si el usuario presiona "ESC"
                if (notas.Equals("Salir", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                    break;
                }

                // Expresión regular para extraer notas y figuras
                string patron = @"\(\s*(do|re|mi|fa|sol|la|si)\s*,\s*(negra|blanca|redonda|corchea|semicorchea)\s*\)";
                Regex re = new Regex(patron, RegexOptions.IgnoreCase);

                // Validar y extraer coincidencias
                MatchCollection matches = re.Matches(notas);
                if (matches.Count > 0)
                {
                    List<(string Nota, string Figura)> listaNotas = new List<(string, string)>();

                    foreach (Match match in matches)
                    {
                        string nota = match.Groups[1].Value.ToLower();  // Normalizar a minúsculas
                        string figura = match.Groups[2].Value.ToLower();  // Normalizar a minúsculas
                        listaNotas.Add((nota, figura));
                    }

                    // Mostrar las notas separadas
                    Console.WriteLine("\nNotas separadas:");
                    foreach (var (nota, figura) in listaNotas)
                    {
                        Console.WriteLine($"Nota: {nota}, Figura: {figura}");
                    }

                    // Creación de la lista enlazada.
                    DoubleLinkedList lista = new DoubleLinkedList();
                    
                    // Añadir cada nota a la lista enlazada.
                    foreach (var (nota, figura) in listaNotas)
                    {
                       lista.agregar(nota, figura);
                    }
                    lista.imprimirLista();
                }
                else
                {
                    Console.WriteLine("El formato no es válido. Intente de nuevo.");
                }
            }
        }
    }
}
