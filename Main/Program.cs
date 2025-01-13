using System;

class Program
{
    static void Main(string[] args)
    {
        Reproductor reproductor = new Reproductor();

        int baseDuration = 1000;

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