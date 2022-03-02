using BenchmarkDotNet.Running;

namespace PixSmith.MicroServices.Poc.AsyncAwait
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Operations>();

            Console.ReadLine();
        }
    }
}