using System.Diagnostics;
using System.Security.Cryptography;

namespace PixSmith.MicroServices.Poc.AsyncAwaitVsSync
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How Many Iterations? (int)");

            var iterations = int.Parse(Console.ReadLine());

            Console.WriteLine("Starting Sync Operations...");

            var syncStopWatch = new Stopwatch();

            syncStopWatch.Start();

            for (int i = 0; i < iterations; i++)
            {
                DoSyncWork();
            }

            syncStopWatch.Stop();

            Console.WriteLine($"Sync stopwatch took {syncStopWatch.ElapsedMilliseconds}ms");

            var syncparallelStopWatch = new Stopwatch();

            syncparallelStopWatch.Start();

            Parallel.For(0, iterations, i =>
            {
                DoSyncWork();
            });

            syncparallelStopWatch.Stop();

            Console.WriteLine($"Parallel sync stopwatch took {syncparallelStopWatch.ElapsedMilliseconds}ms");

            var asyncStopWatch = new Stopwatch();

            var asyncTasks = new Task[iterations];

            asyncStopWatch.Start();

            for (int i = 0; i < iterations; i++)
            {
                asyncTasks[i] = DoAsyncWork();
            }

            Task.WaitAll(asyncTasks);

            asyncStopWatch.Stop();

            Console.WriteLine($"Async stopwatch took {asyncStopWatch.ElapsedMilliseconds}ms \nPress enter to exit...");

            Console.ReadLine();
        }

        private static void DoSyncWork()
        {
            int N = 10000;
            byte[] data;

            data = new byte[N];
            new Random(42).NextBytes(data);

            SHA256 sha256 = SHA256.Create();
            MD5 md5 = MD5.Create();

            sha256.ComputeHash(data);

            Thread.Sleep(1000);

            md5.ComputeHash(data);
        }

        private static async Task DoAsyncWork()
        {
            int N = 10000;
            byte[] data;

            data = new byte[N];
            new Random(42).NextBytes(data);

            SHA256 sha256 = SHA256.Create();
            MD5 md5 = MD5.Create();

            sha256.ComputeHash(data);

            await Task.Delay(1000);

            md5.ComputeHash(data);
        }
    }
}
