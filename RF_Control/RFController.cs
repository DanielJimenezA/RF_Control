using AsyncAwaitBestPractices;
using System;
using System.Diagnostics;
using System.IO;

namespace RF_Control
{
    public static class RFController
    {
        public enum DIRECTIONS
        {
            UP, DOWN, RIGHT, LEFT
        }
        public static void Move(DIRECTIONS direction)
        {
            string wave;
            switch (direction)
            {
                case DIRECTIONS.UP:
                    wave = "Adelante.wav";
                    break;
                case DIRECTIONS.DOWN:
                    wave = "Atras.wav";
                    break;
                case DIRECTIONS.RIGHT:
                    wave = "Derecha.wav";
                    break;
                case DIRECTIONS.LEFT:
                    wave = "Izquierda.wav";
                    break;
                default: throw new ArgumentOutOfRangeException(direction.ToString());
            }
            BroadCast(wave);
        }
        private static void BroadCast(string waveFile)
        {
            FileInfo wavInfo = new FileInfo($"{Environment.CurrentDirectory}/Samples/{waveFile}");
            if (!wavInfo.Exists)
            {
                throw new FileNotFoundException(wavInfo.FullName);
            }
            ProcessStartInfo info = new ProcessStartInfo()
            {
                FileName = $"hackrf_transfer -f 27.145 -s 2 -l 14 -t \"{wavInfo.FullName}\"",
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
            };
            Debug.WriteLine($"MOVE - {waveFile}");
            try
            {
                Process.Start(info).WaitForExitAsync().SafeFireAndForget();
            }
            catch { }
        }
    }
}
