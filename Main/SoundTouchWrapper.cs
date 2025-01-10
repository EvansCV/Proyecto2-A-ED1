using System;
using NAudio.Wave;
using SoundTouch;

public class SoundTouchWrapper : ISampleProvider
{
    private readonly ISampleProvider source;
    private readonly SoundTouchProcessor processor;
    private readonly float[] buffer;
    private int bufferPos;
    private int bufferLength;

    public WaveFormat WaveFormat => source.WaveFormat;

    public SoundTouchWrapper(ISampleProvider source, float speed)
    {
        this.source = source;
        processor = new SoundTouchProcessor
        {
            TempoChange = (speed - 1) * 100 // Ajustar velocidad (1.0 = normal, <1 = más rápido, >1 = más lento)
        };
        buffer = new float[1024];
    }

public int Read(float[] outputBuffer, int offset, int count)
{
    int samplesWritten = 0;

    while (samplesWritten < count)
    {
        if (bufferPos >= bufferLength)
        {
            bufferLength = source.Read(buffer, 0, buffer.Length);
            Console.WriteLine($"Buffer leído: {bufferLength} samples");

            if (bufferLength == 0) break;

            processor.PutSamples(buffer, bufferLength);
            bufferLength = processor.ReceiveSamples(buffer, buffer.Length);
            Console.WriteLine($"Buffer procesado: {bufferLength} samples");

            bufferPos = 0;
        }

        int samplesToCopy = Math.Min(count - samplesWritten, bufferLength - bufferPos);
        Array.Copy(buffer, bufferPos, outputBuffer, offset + samplesWritten, samplesToCopy);
        bufferPos += samplesToCopy;
        samplesWritten += samplesToCopy;
    }

    return samplesWritten;
}
}