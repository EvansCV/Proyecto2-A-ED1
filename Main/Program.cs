using System;

class Program
{
     static void Main(string[] args)
    {
        Console.WriteLine("Seleccione una opción:");
        Console.WriteLine("1. Ejecutar programa");
        Console.WriteLine("2. Ejecutar pruebas");
        string opcion = Console.ReadLine() ?? string.Empty;

        if (opcion == "1")
        {
            // Ejecutar el programa normal
            EjecutarPrograma();
        }
        else if (opcion == "2")
        {
            // Ejecutar pruebas
            Pruebas pruebas = new Pruebas();
            pruebas.EjecutarPruebas();
        }
        else
        {
            Console.WriteLine("Opción no válida.");
        }
    }
 
    
    static void EjecutarPrograma()
    {
                Reproductor reproductor = new Reproductor();

        Console.WriteLine("Introduce la duracion de la negra (100 - 5000ms)");
        Console.WriteLine("Presiona Enter para usar el valor predeterminado de 1000ms");
        int baseDuration;

        string input = Console.ReadLine() ?? string.Empty;

        if (int.TryParse(input, out baseDuration))
        {
            if (baseDuration < 100 || baseDuration > 5000)
            {
                Console.WriteLine("El valor esta fuera de rango, se usara el valor default");
                baseDuration = 1000;
            }
        }

        else
        {
            Console.WriteLine("El valor esta fuera de rango, se usara el valor default");
            baseDuration = 1000;
        }

        Console.WriteLine($"Duracion base para la negra: {baseDuration} ms");

        var melodia = new[]
        {
            new{ Nota = "Do", Figura = "Negra"},
            new { Nota = "Re", Figura = "Blanca" },
            new { Nota = "Mi", Figura = "Corchea" },
            new { Nota = "Fa", Figura = "Semicorchea" },
            new { Nota = "Sol", Figura = "Redonda" },
            new { Nota = "La", Figura = "Negra" },
            new { Nota = "Si", Figura = "Blanca" }
        };

        foreach (var item in melodia)
        {
            if (Notas.Frecuencias.TryGetValue(item.Nota,out double frecuencia) &&
            Figuras.Multiplicadores.TryGetValue(item.Figura, out double Multiplicador))
            {
                int duracion = (int)(baseDuration * Multiplicador);
                Console.WriteLine($"Tocando {item.Nota} ({frecuencia} Hz)");
                reproductor.ReproducirSonido((int)frecuencia, duracion, 75);
                System.Threading.Thread.Sleep(100);
            }
            else
            {
                Console.WriteLine($"Error: Nota o figura musical no encontrada");
            }
        }
        
    }
    }