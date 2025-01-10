using System;
using System.IO;
using NAudio.Wave;

public static class Figura
{
    private static readonly string basePath = AppDomain.CurrentDomain.BaseDirectory;

public static void ReproducirConVelocidad(string fileName, float velocidad)
{
    string filePath = Path.Combine(basePath, fileName);

    if (!File.Exists(filePath))
    {
        Console.WriteLine($"El archivo '{fileName}' no se encontró en la carpeta {basePath}");
        return;
    }

    try
    {
        using (var audioFile = new AudioFileReader(filePath))
        using (var outputDevice = new WaveOutEvent())
        {
            outputDevice.Init(audioFile); // Sin wrapper
            outputDevice.Play();

            Console.WriteLine($"Reproduciendo '{fileName}' sin modificaciones...");

            while (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                System.Threading.Thread.Sleep(100);
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al reproducir el archivo '{fileName}': {ex.Message}");
    }
}

    public static void ReproducirDo(float velocidad){
        ReproducirConVelocidad("DO.mp3", velocidad);
    }

    public static void ReproducirRe(float velocidad){
        ReproducirConVelocidad("RE.mp3", velocidad);
    }

    public static void ReproducirMi(float velocidad){
        ReproducirConVelocidad("MI.mp3", velocidad);
    }

    public static void ReproducirFa(float velocidad){
        ReproducirConVelocidad("FA.mp3", velocidad);
    }

    public static void ReproducirSol(float velocidad){
        ReproducirConVelocidad("SOL.mp3", velocidad);
    }

    public static void ReproducirLa(float velocidad){
        ReproducirConVelocidad("LA.mp3", velocidad);
    }

    public static void ReproducirSi(float velocidad){
        ReproducirConVelocidad("SI.mp3", velocidad);
    }
}