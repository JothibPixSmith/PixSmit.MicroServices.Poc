using Microsoft.EntityFrameworkCore;
using PixSmith.MicroServices.Domain;

namespace PixSmith.MicroServices.Infrastructure.Database
{
    public class PocContext : DbContext
    {
        public PocContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Record> Records { get; set; }
    }
}
