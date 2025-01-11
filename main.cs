// Proyecto Music Box para Datos 1.
// Fecha de Creación: 10 de enero de 2025.
// Autores: Evans Corrales Valverde y Alex Feng Wu.

namespace Proyecto2
{
    // Biblioteca que permite el uso de expresiones regulares.
    using System.Text.RegularExpressions;

    // Inciso 1: El usuario debe ingresar sus partituras como un string usando el siguiente formato


    class Program
    { 
        public static void Main(string[] args) {
        
            // Texto de presentación

            Console.WriteLine("Ingrese sus partituras utilizando el siguiente formato:\n");
            Console.WriteLine("(NOTA 1, FIGURA 1), (NOTA 2, FIGURA 2), ... (NOTA n, FIGURA n)\n");
            Console.WriteLine("Por ejemplo\n");
            Console.WriteLine("(Do, negra), (Re, blanca), (La, Semicorchea)\n");
            Console.WriteLine(@"Si desea salir, presione ""ESC"" ");
            Console.Write("Sus notas: ");

            // Variables que guardan las notas musicales y otra que tiene guardado el formato en el que se debe 
            // ingresar el texto.

            string notas = Console.ReadLine();

            // Definiendo la expresión regular.
            string patron = @"^\(\s*(do|re|mi|fa|sol|la|si)\s*,\s*(negra|blanca|redonda|corchea|semicorchea)\s*\)(,\s*\(\s*(do|re|mi|fa|sol|la|si)\s*,\s*(negra|blanca|redonda|corchea|semicorchea)\s*\))*$";
            Regex re = new Regex(patron, RegexOptions.IgnoreCase);

            // Validar el formato
            if (re.IsMatch(notas))
            {
                Console.WriteLine(notas);
                
                // Ahora se crea la lista doblemente enlazada. Para ello se deben separar la partitura
                // en notas y figuras.
                List<(string Nota, string Figura)> listaNotas = new List<(string, string)>();
                MatchCollection matches = re.Matches(notas);
                foreach (Match match in matches)
                {
                    string nota = match.Groups[1].Value;  // Grupo 1: Nota
                    string figura = match.Groups[2].Value;  // Grupo 2: Figura
                    listaNotas.Add((nota, figura));
                }
                
                // Mostrar las notas en la lista.
                Console.WriteLine("\nNotas separadas:");
                foreach (var (nota, figura) in listaNotas)
                {
                    Console.WriteLine($"Nota: {nota}, Figura: {figura}");
                }
            } else
            {
                Console.WriteLine("El formato no es válido. Intente de nuevo.");
            }
        }
    }
}