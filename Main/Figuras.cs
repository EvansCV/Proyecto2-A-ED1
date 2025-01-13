using System.Collections.Generic;

public static class Figuras
{
    public static readonly Dictionary<string, double> Multiplicadores = new Dictionary<string, double>
    {
        { "Redonda", 4.0 },   // Cuatro tiempos
        { "Blanca", 2.0 },    // Dos tiempos
        { "Negra", 1.0 },     // Un tiempo
        { "Corchea", 0.5 },   // Medio tiempo
        { "Semicorchea", 0.25 } // Un cuarto de tiempo
    };
}