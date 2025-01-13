using System.Collections.Generic;
using NAudio.Wave;
using System;

public static class Notas
{
    public static readonly Dictionary<string, double> Frecuencias = new Dictionary<string, double>
    {
        {"Do", 261.63},
        {"Re", 293.66},
        {"Mi", 329.63},
        {"Fa", 349.23},
        {"Sol", 392.00},
        {"La", 440.00},
        {"Si", 493.88}
    };
}

public class Reproductor
{
    public void ReproducirSonido(int frecuencia, int duracionMs, int volumen = 50)
    {
        int sampleRate = 44100;
        int amplitude = (int)(32760 * (volumen / 100.0));
        int sampleCount = (int)((sampleRate * duracionMs) / 1000.0);

        var waveBuffer = new float[sampleCount];
        double angleIncrement = 2.0 * Math.PI * frecuencia / sampleRate;

        for (int i = 0; i < sampleCount; i++)
        {
            waveBuffer[i] = (float)(amplitude * Math.Sin(i * angleIncrement));
        }

        var waveProvider = new BufferedWaveProvider(new WaveFormat(sampleRate, 16, 1));
        waveProvider.BufferLength = waveBuffer.Length * 2;
        waveProvider.AddSamples(FloatToByteArray(waveBuffer), 0, waveBuffer.Length * 2);

        using (var waveOut = new WaveOutEvent())
        {
            waveOut.Init(waveProvider);
            waveOut.Play();
            System.Threading.Thread.Sleep(duracionMs);
        }
    }

    private byte[] FloatToByteArray(float[] buffer)
    {
        byte[] byteArray = new byte[buffer.Length * 2];
        for (int i = 0; i < buffer.Length; i++)
        {
            short value = (short)(buffer[i]);
            byteArray[i * 2] = (byte)(value & 0xFF);
            byteArray[i * 2 + 1] = (byte)((value >> 8) & 0xFF);
        }

        return byteArray;
    }
}