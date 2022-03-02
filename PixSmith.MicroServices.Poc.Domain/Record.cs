using PixSmith.MicroServices.Domain.Enums;

namespace PixSmith.MicroServices.Domain
{
    public class Record
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public string Name { get; set; }

        public RecordType Type { get; set; }

        public DateTime DateReleased { get; set; }

        public Artist? Artist { get; set; }
    }
}
