namespace PixSmith.MicroServices.Domain
{
    public class Artist
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public string Name { get; set; }

        public List<Record>? Discography { get; set; }
    }
}
