using PixSmith.MicroServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
// see https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-source-generator/
namespace PixSmith.MicroServices.Poc.Infrastructure.JsonContexts.Domain
{
    [JsonSerializable(typeof(Artist))]
    public partial class ArtistContext : JsonSerializerContext
    {
    }
}
