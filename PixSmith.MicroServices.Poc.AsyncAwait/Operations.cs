using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using PixSmith.MicroServices.Domain;
using PixSmith.MicroServices.Poc.AsyncAwait.Context;
using PixSmith.MicroServices.Poc.Infrastructure.JsonContexts.Domain;
using System.Text;
using System.Text.Json;

namespace PixSmith.MicroServices.Poc.AsyncAwait
{
    [MemoryDiagnoser]
    public class Operations
    {
        [Benchmark]
        public async Task ProcessOperationsAsync()
        {
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("https://localhost:7269");

            var jsonSerializerOptions = new JsonSerializerOptions();

            jsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

            var newArtists = new List<Artist>();

            foreach (var artist in AsyncAwaitContext.Artists)
            {
                HttpResponseMessage result = await httpClient.PostAsync("api/Artist/save", new StringContent(JsonSerializer.Serialize(artist, ArtistContext.Default.Artist), Encoding.UTF8, "application/json"));

                newArtists.Add(JsonSerializer.Deserialize<Artist>(await result.Content.ReadAsStringAsync(), jsonSerializerOptions));
            }

            foreach (var artist in newArtists)
            {
                HttpResponseMessage result = await httpClient.GetAsync($"api/Artist/{artist.Guid}");

                var currentArtist = JsonSerializer.Deserialize<Artist>(await result.Content.ReadAsStringAsync());
            }

            foreach (var artist in newArtists)
            {
                HttpResponseMessage result = await httpClient.DeleteAsync($"api/Artist/delete/{artist.Guid}");
            }
        }

        [Benchmark]
        public void ProcessOperationsSync()
        {
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("https://localhost:7269");

            var jsonSerializerOptions = new JsonSerializerOptions();

            jsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

            var newArtists = new List<Artist>();

            foreach (var artist in AsyncAwaitContext.Artists)
            {
                HttpResponseMessage result = httpClient.PostAsync("api/ArtistSync/save", new StringContent(JsonSerializer.Serialize(artist, ArtistContext.Default.Artist), Encoding.UTF8, "application/json")).Result;

                var stringResult = result.Content.ReadAsStringAsync().Result;

                newArtists.Add(JsonSerializer.Deserialize<Artist>(result.Content.ReadAsStringAsync().Result, jsonSerializerOptions));
            }

            foreach (var artist in newArtists)
            {
                HttpResponseMessage result = httpClient.GetAsync($"api/ArtistSync/{artist.Guid}").Result;

                var currentArtist = JsonSerializer.Deserialize<Artist>(result.Content.ReadAsStringAsync().Result);
            }

            foreach (var artist in newArtists)
            {
                HttpResponseMessage result = httpClient.DeleteAsync($"api/ArtistSync/delete/{artist.Guid}").Result;
            }
        }
    }
}
