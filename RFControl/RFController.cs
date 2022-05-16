using AsyncAwaitBestPractices;
using System.Diagnostics;

namespace RFControl
{
    public static class RFController
    {
        public static void Move(DIRECTIONS direction)
        {
            string wave;
            switch (direction)
            {
                case DIRECTIONS.UP:
                    wave = "adelante";
                    break;
                case DIRECTIONS.DOWN:
                    wave = "atras";
                    break;
                case DIRECTIONS.RIGHT:
                    wave = "derecha";
                    break;
                case DIRECTIONS.LEFT:
                    wave = "izquierda";
                    break;
                default: throw new ArgumentOutOfRangeException(direction.ToString());
            }
            BroadCast(wave);
        }
        private static void BroadCast(string waveFile)
        {
            //sudo hackrf_transfer -f 27000000 -s 2000000 -t izquierda
            FileInfo wavInfo = new FileInfo($"{Environment.CurrentDirectory}/Samples/{waveFile}");
            if (!wavInfo.Exists)
            {
                throw new FileNotFoundException(wavInfo.FullName);
            }
            string cmd = $"sudo hackrf_transfer -f 27000000 -s 2000000 -t \"{wavInfo.FullName}\"";
            Console.Write(cmd);
            ProcessStartInfo info = new ProcessStartInfo()
            {
                FileName = "/bin/bash",
                Arguments = $"-c \"{cmd}\"",
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
            };
            Debug.WriteLine($"MOVE - {waveFile}");
            try
            {
                Process.Start(info)?.WaitForExitAsync().SafeFireAndForget();
            }
            catch { }
        }
    }
}
