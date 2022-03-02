using PixSmith.MicroServices.Domain;
using System.Text.Json.Serialization;

namespace PixSmith.MicroServices.Poc.Infrastructure.JsonContexts.Domain
{
    [JsonSerializable(typeof(Record))]
    public partial class RecordContext : JsonSerializerContext
    {
    }
}
