using NAudio.Wave;

public static class SFX
{
    private static readonly WaveOutEvent _musicOut = new WaveOutEvent();
    private static AudioFileReader? _musicReader;
    private static LoopStream? _musicLoop;

    public static void PlayMusicLoop(string path, float volume = 0.25f)
    {
        StopMusic();

        _musicReader = new AudioFileReader(path) { Volume = volume };
        _musicLoop = new LoopStream(_musicReader);

        _musicOut.Init(_musicLoop);
        _musicOut.Play();
    }

    public static void PlaySfx(string path, float volume = 0.8f)
    {
        var reader = new AudioFileReader(path) { Volume = volume };
        var output = new WaveOutEvent();

        output.Init(reader);
        output.PlaybackStopped += (_, __) =>
        {
            output.Dispose();
            reader.Dispose();
        };
        output.Play();
    }

    public static void StopMusic()
    {
        _musicOut.Stop();
        _musicLoop?.Dispose();
        _musicReader?.Dispose();
        _musicLoop = null;
        _musicReader = null;
    }

    private sealed class LoopStream : WaveStream
    {
        private readonly WaveStream _source;
        public LoopStream(WaveStream source) => _source = source;

        public override WaveFormat WaveFormat => _source.WaveFormat;
        public override long Length => long.MaxValue;

        public override long Position
        {
            get => _source.Position;
            set => _source.Position = value;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int read = _source.Read(buffer, offset, count);
            if (read == 0)
            {
                _source.Position = 0;
                read = _source.Read(buffer, offset, count);
            }
            return read;
        }
    }
}
