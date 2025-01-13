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

        // Probar reproducción de sonido con figuras
        TestReproduccionSonidoconFigura();

        // Probar valor nuevo de negra
        TestModificarValorDeLaNegra();

        TestSonidoConNegraModificada();


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

        private void TestReproduccionSonidoconFigura()
    {
        Console.WriteLine("Probando reproducción de sonido con figura...");

        Reproductor reproductor = new Reproductor();
        int baseDuration = 1000; // Duración base para la figura negra

        string nota = "Do";

        if (!Notas.Frecuencias.TryGetValue(nota, out double frecuencia))
        {
            Console.WriteLine($"Error: Nota {nota} no encontrada en el diccionario.");
            return;
        }

        foreach (var figura in Figuras.Multiplicadores)
        {
            string nombreFigura = figura.Key;
            double multiplicador = figura.Value;

            int duracion = (int)(baseDuration * multiplicador);
            Console.WriteLine($"Tocando {nota} ({frecuencia} Hz) como {nombreFigura} durante {duracion} ms...");

            try
            {
                reproductor.ReproducirSonido((int)frecuencia, duracion, 75);
                Console.WriteLine($"{nombreFigura} reproducida correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al reproducir la figura {nombreFigura}: {ex.Message}");
            }
        }

        Console.WriteLine("Prueba de reproducción de sonido con figuras completada.");
    }

    public void TestModificarValorDeLaNegra()
    {
        Console.WriteLine("Probando modificación del valor de la figura negra...");

        Console.WriteLine("Introduce un nuevo valor para la figura negra (100 - 5000 ms):");
        Console.WriteLine("Presiona Enter para usar el valor predeterminado de 1000 ms.");
        int baseDuration;

        string input = Console.ReadLine() ?? string.Empty;

        // Validar la entrada del usuario
        if (int.TryParse(input, out baseDuration))
        {
            if (baseDuration < 100 || baseDuration > 5000)
            {
                Console.WriteLine("El valor está fuera de rango. Se usará el valor predeterminado de 1000 ms.");
                baseDuration = 1000;
            }
        }
        else
        {
            Console.WriteLine("Entrada no válida. Se usará el valor predeterminado de 1000 ms.");
            baseDuration = 1000;
        }

        Console.WriteLine($"Duración base para la negra: {baseDuration} ms");

        // Verificar que las demás figuras se ajusten correctamente
        Console.WriteLine("Verificando duración de las demás figuras...");
        foreach (var figura in Figuras.Multiplicadores)
        {
            string nombreFigura = figura.Key;
            double multiplicador = figura.Value;

            int duracion = (int)(baseDuration * multiplicador);
            Console.WriteLine($"Figura: {nombreFigura}, Multiplicador: {multiplicador}, Duración calculada: {duracion} ms");
        }

        Console.WriteLine("Prueba de modificación del valor de la negra completada.");
    }

     public void TestSonidoConNegraModificada()
    {
        Console.WriteLine("Probando reproducción de sonido con figura negra modificada...");

        // Pedir el valor de la negra al usuario
        Console.WriteLine("Introduce un nuevo valor para la figura negra (100 - 5000 ms):");
        Console.WriteLine("Presiona Enter para usar el valor predeterminado de 1000 ms.");
        int baseDuration;

        string input = Console.ReadLine() ?? string.Empty;

        // Validar la entrada del usuario
        if (int.TryParse(input, out baseDuration))
        {
            if (baseDuration < 100 || baseDuration > 5000)
            {
                Console.WriteLine("El valor está fuera de rango. Se usará el valor predeterminado de 1000 ms.");
                baseDuration = 1000;
            }
        }
        else
        {
            Console.WriteLine("Entrada no válida. Se usará el valor predeterminado de 1000 ms.");
            baseDuration = 1000;
        }

        Console.WriteLine($"Duración base para la negra: {baseDuration} ms");

        // Obtener la frecuencia de la nota "Do"
        string nota = "Do";
        if (!Notas.Frecuencias.TryGetValue(nota, out double frecuencia))
        {
            Console.WriteLine($"Error: Nota {nota} no encontrada en el diccionario.");
            return;
        }

        Reproductor reproductor = new Reproductor();

        // Reproducir el sonido para cada figura musical
        foreach (var figura in Figuras.Multiplicadores)
        {
            string nombreFigura = figura.Key;
            double multiplicador = figura.Value;

            int duracion = (int)(baseDuration * multiplicador);
            Console.WriteLine($"Tocando {nota} ({frecuencia} Hz) como {nombreFigura} durante {duracion} ms...");

            try
            {
                reproductor.ReproducirSonido((int)frecuencia, duracion, 75);
                Console.WriteLine($"{nombreFigura} reproducida correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al reproducir la figura {nombreFigura}: {ex.Message}");
            }
        }

        Console.WriteLine("Prueba de sonido con figura negra modificada completada.");
    }
}


