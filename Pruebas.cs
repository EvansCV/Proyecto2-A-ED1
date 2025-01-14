using System.Text.RegularExpressions;
namespace Proyecto2 {
    public class Pruebas
    {
        public void EjecutarPruebas()
        {
            var pruebas = new Action[]
            {
                TestDiccionarioNotas,
                TestDiccionarioFiguras,
                TestReproduccionSonido,
                TestReproduccionSonidoconFigura,
                TestModificarValorDeLaNegra,
                TestSonidoConNegraModificada,
                TestGuardarMelodia,
                TestProbarMelodia,
                TestProbarMelodiaReves,
                TestTwinkleLittleStar
            };

            foreach (var prueba in pruebas) {
                prueba();
                Thread.Sleep(5000); // Delay de 5 segundos que debe haber entre cada prueba.
            }
            Console.WriteLine("Todas las pruebas se completaron.");
        }

        private void TestDiccionarioNotas()
        {
            Console.WriteLine("Probando diccionario de notas...");

            string[] notasEsperadas = { "do", "re", "mi", "fa", "sol", "la", "si" };

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

            string[] figurasEsperadas = { "redonda", "blanca", "negra", "corchea", "semicorchea" };

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
                reproductor.ReproducirSonido((int)Notas.Frecuencias["do"], 1000, 75);

                Console.WriteLine("Reproduciendo un sonido de prueba (Re, 1 segundo)...");
                reproductor.ReproducirSonido((int)Notas.Frecuencias["re"], 1000, 75);

                Console.WriteLine("Reproduciendo un sonido de prueba (Mi, 1 segundo)...");
                reproductor.ReproducirSonido((int)Notas.Frecuencias["mi"], 1000, 75);

                Console.WriteLine("Reproduciendo un sonido de prueba (Fa, 1 segundo)...");
                reproductor.ReproducirSonido((int)Notas.Frecuencias["fa"], 1000, 75);

                Console.WriteLine("Reproduciendo un sonido de prueba (Sol, 1 segundo)...");
                reproductor.ReproducirSonido((int)Notas.Frecuencias["sol"], 1000, 75);

                Console.WriteLine("Reproduciendo un sonido de prueba (La, 1 segundo)...");
                reproductor.ReproducirSonido((int)Notas.Frecuencias["la"], 1000, 75);

                Console.WriteLine("Reproduciendo un sonido de prueba (Si, 1 segundo)...");
                reproductor.ReproducirSonido((int)Notas.Frecuencias["si"], 1000, 75);

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

            string nota = "do";

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

            Console.WriteLine("Introduce un nuevo valor para la figura negra (200 - 5000 ms):");
            Console.WriteLine("Presiona Enter para usar el valor predeterminado de 1000 ms.");
            Console.Write("Valor de la negra: ");
            int baseDuration;

            string input = Console.ReadLine() ?? string.Empty;

            // Validar la entrada del usuario
            if (int.TryParse(input, out baseDuration))
            {
                if (baseDuration < 200 || baseDuration > 5000)
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
            Console.WriteLine("Introduce un nuevo valor para la figura negra (200 - 5000 ms):");
            Console.WriteLine("Presiona Enter para usar el valor predeterminado de 1000 ms.");
            Console.Write("Valor de la negra: ");
            int baseDuration;

            string input = Console.ReadLine() ?? string.Empty;

            // Validar la entrada del usuario
            if (int.TryParse(input, out baseDuration))
            {
                if (baseDuration < 200 || baseDuration > 5000)
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
            string nota = "do";
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

        public void TestGuardarMelodia() {
            Console.WriteLine("Test para comprobar que las notas se guardaron en la lista enlazada correctamente.");
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

                foreach (Match match in matches)
                {
                    string nota = match.Groups[1].Value.ToLower();  // Normalizar a minúsculas
                    string figura = match.Groups[2].Value.ToLower();  // Normalizar a minúsculas
                    listaNotas.agregar(nota, figura);
                }
                listaNotas.imprimirLista();
            }
            Console.WriteLine("Prueba completada");
        }
        public void TestProbarMelodia() {
            Console.WriteLine("Test para comprobar que las notas de la lista enlazada se reproducen correctamente.");
            Console.WriteLine("Para este test se utilizará el valor de la negra de un segundo");
            Console.WriteLine("Ingrese sus partituras utilizando el siguiente formato:\n");
            Console.WriteLine("(NOTA 1, FIGURA 1), (NOTA 2, FIGURA 2), ... (NOTA n, FIGURA n)\n");
            Console.WriteLine("Por ejemplo\n");
            Console.WriteLine("(Do, negra), (Re, blanca), (La, Semicorchea)\n");

            Console.Write("Sus notas: ");
            var notas = Console.ReadLine();

            // Necesario para que se reproduzca la lista enlazada.
            Reproductor reproductor= new Reproductor();

            // Expresión regular para extraer notas y figuras
            string patron = @"\(\s*(do|re|mi|fa|sol|la|si)\s*,\s*(negra|blanca|redonda|corchea|semicorchea)\s*\)";
            Regex re = new Regex(patron, RegexOptions.IgnoreCase);

            // Validar y extraer coincidencias
            MatchCollection matches = re.Matches(notas);
            if (matches.Count > 0)
            {
                // Creación de la lista enlazada.
                DoubleLinkedList listaNotas = new DoubleLinkedList();

                foreach (Match match in matches)
                {
                    string nota = match.Groups[1].Value.ToLower();  // Normalizar a minúsculas
                    string figura = match.Groups[2].Value.ToLower();  // Normalizar a minúsculas
                    listaNotas.agregar(nota, figura);
                }

                listaNotas.listaDerecha(1000, reproductor);
            }
            Console.WriteLine("Prueba completada");
        }
        public void TestProbarMelodiaReves() {
            Console.WriteLine("Test para comprobar que las notas de la lista enlazada se reproducen al revés de forma correcta.");
            Console.WriteLine("Para este test se utilizará el valor de la negra de un segundo");
            Console.WriteLine("Ingrese sus partituras utilizando el siguiente formato:\n");
            Console.WriteLine("(NOTA 1, FIGURA 1), (NOTA 2, FIGURA 2), ... (NOTA n, FIGURA n)\n");
            Console.WriteLine("Por ejemplo\n");
            Console.WriteLine("(Do, negra), (Re, blanca), (La, Semicorchea)\n");

            Console.Write("Sus notas: ");
            var notas = Console.ReadLine();

            // Necesario para que se reproduzca la lista enlazada.
            Reproductor reproductor= new Reproductor();

            // Expresión regular para extraer notas y figuras
            string patron = @"\(\s*(do|re|mi|fa|sol|la|si)\s*,\s*(negra|blanca|redonda|corchea|semicorchea)\s*\)";
            Regex re = new Regex(patron, RegexOptions.IgnoreCase);

            // Validar y extraer coincidencias
            MatchCollection matches = re.Matches(notas);
            if (matches.Count > 0)
            {
                // Creación de la lista enlazada.
                DoubleLinkedList listaNotas = new DoubleLinkedList();

                foreach (Match match in matches)
                {
                    string nota = match.Groups[1].Value.ToLower();  // Normalizar a minúsculas
                    string figura = match.Groups[2].Value.ToLower();  // Normalizar a minúsculas
                    listaNotas.agregar(nota, figura);
                }

                listaNotas.listaReversa(1000, reproductor);
            }
            Console.WriteLine("Prueba completada");
        }

        public void TestTwinkleLittleStar() {
            Console.WriteLine("Test para reproducir alguna melodía con diferentes valores de la negra y el uso de listas enlazadas.");
            Console.WriteLine("Se reproducirá una melodía similar a Twinkle Little Star según el valor que escriba de la negra.");
            // Pedir el valor de la negra al usuario
            Console.WriteLine("Introduce un nuevo valor para la figura negra (200 - 5000 ms):");
            Console.WriteLine("Presiona Enter para usar el valor predeterminado de 1000 ms.");
            Console.Write("Valor de la negra: ");
            int baseDuration;

            string input = Console.ReadLine() ?? string.Empty;

            // Validar la entrada del usuario
            if (int.TryParse(input, out baseDuration))
            {
                if (baseDuration < 200 || baseDuration > 5000)
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

            Reproductor reproductor= new Reproductor();

            string patron = @"\(\s*(do|re|mi|fa|sol|la|si)\s*,\s*(negra|blanca|redonda|corchea|semicorchea)\s*\)";
            string melodia = "(Do, negra), (Do, negra), (Sol, negra), (Sol, negra), (La, blanca), (Sol, blanca), (Fa, negra), (Fa, negra), (Mi, negra), (Mi, negra), (Re, blanca), (Do, blanca)";
            Regex re = new Regex(patron, RegexOptions.IgnoreCase);
            MatchCollection matches = re.Matches(melodia);
            
            if (matches.Count > 0)
            {
                // Creación de la lista enlazada.
                DoubleLinkedList listaMelodia = new DoubleLinkedList();

                foreach (Match match in matches)
                {
                    string nota = match.Groups[1].Value.ToLower();  // Normalizar a minúsculas
                    string figura = match.Groups[2].Value.ToLower();  // Normalizar a minúsculas
                    listaMelodia.agregar(nota, figura);
                }
                Console.WriteLine("Lista enlazada creada:");
                listaMelodia.imprimirLista();
                listaMelodia.listaDerecha(baseDuration, reproductor);
                Console.WriteLine("Prueba completada");
            }
        }
    }
}
