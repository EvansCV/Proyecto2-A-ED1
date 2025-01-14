public static class Figuras
{
    public static readonly Dictionary<string, double> Multiplicadores = new Dictionary<string, double>
    {
        { "redonda", 4.0 },   // Cuatro tiempos
        { "blanca", 2.0 },    // Dos tiempos
        { "negra", 1.0 },     // Un tiempo
        { "corchea", 0.5 },   // Medio tiempo
        { "semicorchea", 0.25 } // Un cuarto de tiempo
    };
}