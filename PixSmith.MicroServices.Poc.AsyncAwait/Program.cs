using PixSmith.MicroServices.Domain;
using PixSmith.MicroServices.Poc.AsyncAwait.Context;
using PixSmith.MicroServices.Poc.Infrastructure.JsonContexts.Domain;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace PixSmith.MicroServices.Poc.AsyncAwait
{
    internal class Program
    {
        private static HttpClient HttpClient;

        private static JsonSerializerOptions JsonSerializerOptions;

        static async Task Main(string[] args)
        {
            HttpClient = new HttpClient();

            HttpClient.BaseAddress = new Uri("https://localhost:7269");

            JsonSerializerOptions = new JsonSerializerOptions();

            JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

            Console.WriteLine("How many iterations would you like to see (int)?");

            var iterations = int.Parse(Console.ReadLine());

            Console.WriteLine("Hit enter to start...");

            Console.ReadLine();

            var syncStopWatch = new Stopwatch();

            syncStopWatch.Start();

            for(int i=0; i< iterations + 1; i++)
            {
                ProcessOperationsSync();
            }

            syncStopWatch.Stop();

            Console.WriteLine($"Sync Operation Took: {syncStopWatch.ElapsedMilliseconds}");

            var parallelStopwatch = new Stopwatch();

            parallelStopwatch.Start();

            Parallel.For(0, iterations, i =>
             {
                 ProcessOperationsSync();
             });

            parallelStopwatch.Stop();

            Console.WriteLine($"Parallel Sync Operation Took: {parallelStopwatch.ElapsedMilliseconds}");

            var asyncStopWatch = new Stopwatch();

            var asyncOperations = new List<Task>();

            asyncStopWatch.Start();

            for (int i = 0; i < iterations + 1; i++)
            {
                asyncOperations.Add(ProcessOperationsAsync());
            }

            await Task.WhenAll(asyncOperations);

            asyncStopWatch.Stop();

            Console.WriteLine($"Async Operation Took: {asyncStopWatch.ElapsedMilliseconds}");

            Console.ReadLine();
        }

        private static async Task ProcessOperationsAsync()
        {
            var newArtists = new List<Artist>();

            foreach (var artist in AsyncAwaitContext.Artists)
            {
                HttpResponseMessage result = await HttpClient.PostAsync("api/Artist/save", new StringContent(JsonSerializer.Serialize(artist, ArtistContext.Default.Artist), Encoding.UTF8, "application/json"));

                newArtists.Add(JsonSerializer.Deserialize<Artist>(await result.Content.ReadAsStringAsync(), JsonSerializerOptions));
            }

            foreach(var artist in newArtists)
            {
                HttpResponseMessage result = await HttpClient.GetAsync($"api/Artist/{artist.Guid}");

                var currentArtist = JsonSerializer.Deserialize<Artist>(await result.Content.ReadAsStringAsync());
            }

            foreach (var artist in newArtists)
            {
                HttpResponseMessage result = await HttpClient.DeleteAsync($"api/Artist/delete/{artist.Guid}");
            }
        }

        private static void ProcessOperationsSync()
        {
            var newArtists = new List<Artist>();

            foreach (var artist in AsyncAwaitContext.Artists)
            {
                HttpResponseMessage result = HttpClient.PostAsync("api/Artist/save", new StringContent(JsonSerializer.Serialize(artist, ArtistContext.Default.Artist), Encoding.UTF8, "application/json")).Result;

                var stringResult = result.Content.ReadAsStringAsync().Result;

                newArtists.Add(JsonSerializer.Deserialize<Artist>(result.Content.ReadAsStringAsync().Result,JsonSerializerOptions));
            }

            foreach (var artist in newArtists)
            {
                HttpResponseMessage result = HttpClient.GetAsync($"api/Artist/{artist.Guid}").Result;

                var currentArtist = JsonSerializer.Deserialize<Artist>(result.Content.ReadAsStringAsync().Result);
            }

            foreach (var artist in newArtists)
            {
                HttpResponseMessage result = HttpClient.DeleteAsync($"api/Artist/delete/{artist.Guid}").Result;
            }
        }
    }
}