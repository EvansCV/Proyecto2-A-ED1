using System;

class Pruebas
{
    public void EjecutarPruebas()
    {
        Console.WriteLine("Iniciando pruebas...");

        // Probar diccionario de notas
        TestDiccionarioNotas();

        // Probar diccionario de figuras musicales
        TestDiccionarioFiguras();

        // Probar reproducción de sonido
        TestReproduccionSonido();

        Console.WriteLine("Todas las pruebas se completaron.");
    }

    private void TestDiccionarioNotas()
    {
        Console.WriteLine("Probando diccionario de notas...");

        string[] notasEsperadas = { "Do", "Re", "Mi", "Fa", "Sol", "La", "Si" };

        foreach (var nota in notasEsperadas)
        {
            if (!Notas.Frecuencias.ContainsKey(nota))
            {
                Console.WriteLine($"Error: Nota {nota} no encontrada en el diccionario.");
            }
            else
            {
                Console.WriteLine($"Nota {nota} encontrada con frecuencia {Notas.Frecuencias[nota]} Hz.");
            }
        }

        Console.WriteLine("Prueba de diccionario de notas completada.");
    }

    private void TestDiccionarioFiguras()
    {
        Console.WriteLine("Probando diccionario de figuras musicales...");

        string[] figurasEsperadas = { "Redonda", "Blanca", "Negra", "Corchea", "Semicorchea" };

        foreach (var figura in figurasEsperadas)
        {
            if (!Figuras.Multiplicadores.ContainsKey(figura))
            {
                Console.WriteLine($"Error: Figura {figura} no encontrada en el diccionario.");
            }
            else
            {
                Console.WriteLine($"Figura {figura} encontrada con multiplicador {Figuras.Multiplicadores[figura]}.");
            }
        }

        Console.WriteLine("Prueba de diccionario de figuras musicales completada.");
    }

    private void TestReproduccionSonido()
    {
        Console.WriteLine("Probando reproducción de sonido...");

        Reproductor reproductor = new Reproductor();

        // Probar la reproducción de un tono básico (Do, negra)
        try
        {
            Console.WriteLine("Reproduciendo un sonido de prueba (Do, 1 segundo)...");
            reproductor.ReproducirSonido((int)Notas.Frecuencias["Do"], 1000, 75);

            Console.WriteLine("Reproduciendo un sonido de prueba (Re, 1 segundo)...");
            reproductor.ReproducirSonido((int)Notas.Frecuencias["Re"], 1000, 75);

            Console.WriteLine("Reproduciendo un sonido de prueba (Mi, 1 segundo)...");
            reproductor.ReproducirSonido((int)Notas.Frecuencias["Mi"], 1000, 75);

            Console.WriteLine("Reproduciendo un sonido de prueba (Fa, 1 segundo)...");
            reproductor.ReproducirSonido((int)Notas.Frecuencias["Fa"], 1000, 75);

            Console.WriteLine("Reproduciendo un sonido de prueba (Sol, 1 segundo)...");
            reproductor.ReproducirSonido((int)Notas.Frecuencias["Sol"], 1000, 75);

            Console.WriteLine("Reproduciendo un sonido de prueba (La, 1 segundo)...");
            reproductor.ReproducirSonido((int)Notas.Frecuencias["La"], 1000, 75);

            Console.WriteLine("Reproduciendo un sonido de prueba (Si, 1 segundo)...");
            reproductor.ReproducirSonido((int)Notas.Frecuencias["Si"], 1000, 75);

            Console.WriteLine("Reproducción de sonido completada sin errores.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error durante la reproducción de sonido: {ex.Message}");
        }
    }
}