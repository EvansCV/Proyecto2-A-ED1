// Proyecto Music Box para Datos 1.
// Fecha de Creación: 10 de enero de 2025.
// Autores: Evans Corrales Valverde y Alex Feng Wu.

namespace Proyecto2
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        public static void Main(string[] args) {
            while (true) {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Ejecutar programa");
                Console.WriteLine("2. Ejecutar pruebas");
                Console.WriteLine("3. Salir del programa");
                Console.Write("Opción: ");
                string opcion = Console.ReadLine() ?? string.Empty;

                if (opcion == "1") {
                    ejecutarPrograma();
                } else if (opcion == "2") {
                    Pruebas prueba = new Pruebas();
                    prueba.EjecutarPruebas();
                } else if (opcion == "3") {
                    break;
                } else {
                    Console.WriteLine("La opción seleccionada no es válida. Por favor, intente nuevamente.");
                }
            }
        }

        static void ejecutarPrograma() {
            
            // Inicializar la instancia del reproductor.
            Reproductor reproductor = new Reproductor();
            Console.WriteLine("Introduce la duracion de la negra (100 - 5000ms)");
            Console.WriteLine("Presiona Enter para usar el valor predeterminado de 1000ms");
            Console.Write("Valor de la negra: ");
            int baseDuration;

            string input = Console.ReadLine() ?? string.Empty;

            // Condicional para determinar si la entrada se encuentra dentro del rango establecido
            // sino utilizar el default baseDuration = 1000(1 segundo).
            if (int.TryParse(input, out baseDuration)){
                if (baseDuration < 200 || baseDuration > 5000)
                {
                    Console.WriteLine("El valor esta fuera de rango, se usara el valor default");
                    baseDuration = 1000;
                }
            } else {
                Console.WriteLine("El valor esta fuera de rango, se usara el valor default");
                baseDuration = 1000;
            }

            Console.WriteLine($"Duracion base para la negra: {baseDuration} ms");

            // Texto de presentación
            Console.WriteLine("Ingrese sus partituras utilizando el siguiente formato:\n");
            Console.WriteLine("(NOTA 1, FIGURA 1), (NOTA 2, FIGURA 2), ... (NOTA n, FIGURA n)\n");
            Console.WriteLine("Por ejemplo\n");
            Console.WriteLine("(Do, negra), (Re, blanca), (La, Semicorchea)\n");

            Console.Write("Sus notas: ");
            var notas = Console.ReadLine();

            // Expresión regular para extraer notas y figuras
            string patron = @"\(\s*(do|re|mi|fa|sol|la|si)\s*,\s*(negra|blanca|redonda|corchea|semicorchea)\s*\)";
            Regex re = new Regex(patron, RegexOptions.IgnoreCase);

            // Validar y extraer coincidencias
            MatchCollection matches = re.Matches(notas);
            if (matches.Count > 0)
            {
                // Creación de la lista enlazada.
                DoubleLinkedList listaNotas = new DoubleLinkedList();

                // Evalua cada "match" existente donde haya coincidencias del patron que se generó entre el
                // re y notas, para luego crear la lista enlazada.
                foreach (Match match in matches)
                {
                    string nota = match.Groups[1].Value.ToLower();  // Normalizar a minúsculas
                    string figura = match.Groups[2].Value.ToLower();  // Normalizar a minúsculas
                    listaNotas.agregar(nota, figura);
                }
                while (true) {
                    Console.WriteLine("1. Reproducir al derecho.");
                    Console.WriteLine("2. Reproducir al revés.");
                    Console.WriteLine("3. Volver");
                    Console.Write("Opción: ");
                    string entry = Console.ReadLine() ?? string.Empty;
                    if (entry == "1") {
                        listaNotas.listaDerecha(baseDuration, reproductor);
                    } else if (entry == "2") {
                        listaNotas.listaReversa(baseDuration, reproductor);
                    } else if (entry == "3") {
                        break;
                    } else {
                        Console.WriteLine("La opción seleccionada no es válida. Por favor, intente nuevamente.");
                    }
                }
            } else {
                Console.WriteLine("El formato no es válido. Intente de nuevo.");
            }
        } 
    }
}
