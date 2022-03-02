using PixSmith.MicroServices.Domain;
using System.Text.Json.Serialization;
// see https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-source-generator/
namespace PixSmith.MicroServices.Poc.Infrastructure.JsonContexts.Domain
{
    [JsonSerializable(typeof(Artist))]
    public partial class ArtistContext : JsonSerializerContext
    {
    }
}
