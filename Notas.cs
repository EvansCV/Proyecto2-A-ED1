using NAudio.Wave;

public static class Notas
{
    public static readonly Dictionary<string, double> Frecuencias = new Dictionary<string, double>
    {
        {"do", 261.63},
        {"re", 293.66},
        {"mi", 329.63},
        {"fa", 349.23},
        {"sol", 392.00},
        {"la", 440.00},
        {"si", 493.88}
    };
}

public class Reproductor
{   // Este método permite reproducir el sonido con la frecuencia y duración que son modificados según los
    // argumentos enviados.
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