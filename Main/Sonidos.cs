namespace Sonidos;
using System;
using System.IO;
using NAudio.CoreAudioApi;
using NAudio.Wave;

public static class Reproductor
{
    private static readonly string basePath = AppDomain.CurrentDomain.BaseDirectory;

    public static void Reproducir(string fileName){
        string filePath = Path.Combine(basePath, fileName);

        if (!File.Exists(filePath)){
            Console.WriteLine($"El archivo '{fileName}' no se encontro en la carpeta:{basePath}");
            return;
        }

        try{
            using (var audioFile = new AudioFileReader(filePath))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();

                Console.WriteLine($"Reprudciendo: {fileName}");
                while (outputDevice.PlaybackState == PlaybackState.Playing){

                    //Funcion que hace que se espere hasta que termine la reproduccion
                    System.Threading.Thread.Sleep(100);
                }
            }
        }
        catch (Exception ex){
            Console.WriteLine($"Error al reproducir el archivo '{fileName}':{ex.Message}");
        }
    } 

    public static void ReproducirDo(){
        Reproducir("DO.mp3");
    }

    public static void ReproducirRe(){
        Reproducir("RE.mp3");
    }

    public static void ReproducirMi(){
        Reproducir("MI.mp3");
    }

    public static void ReproducirFa(){
        Reproducir("FA.mp3");
    }

    public static void ReproducirSol(){
        Reproducir("SOL.mp3");
    }

    public static void ReproducirLa(){
        Reproducir("LA.mp3");
    }

    public static void ReproducirSi(){
        Reproducir("SI.mp3");
    }
}
