using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using PixSmith.MicroServices.Domain;
using PixSmith.MicroServices.Infrastructure.Database;

namespace PixSmith.MicroServices.Infrastructure.Repositories.IntegrationTests.Context
{
    public class ArtistRepositoryContext
    {
        protected async Task GivenSQLLiteTestDB()
        {
            DbContext = new PocContext(new DbContextOptionsBuilder<PocContext>()
                .UseSqlite("Filename=testDb.db")
                .Options);

            await DbContext.Artists.AddRangeAsync(new[]
            {
                new Artist
                {
                    Id = 1,
                    Guid = System.Guid.NewGuid(),
                    Name = "test1234dddddddddddddddddddddd",
                    Discography = new System.Collections.Generic.List<Record>
                    {
                        new Record
                        {
                            Id=1,
                            Guid=System.Guid.NewGuid(),
                            Name = "record1ForArtist1"
                        },
                        new Record
                        {
                            Id=2,
                            Guid=System.Guid.NewGuid(),
                            Name = "record2ForArtist1"
                        },
                        new Record
                        {
                            Id=3,
                            Guid=System.Guid.NewGuid(),
                            Name = "record3ForArtist1"
                        }
                    }
                },
                 new Artist
                {
                    Id = 2,
                    Guid = System.Guid.NewGuid(),
                    Name = "test1235sdafsdd",
                    Discography = new System.Collections.Generic.List<Record>
                    {
                        new Record
                        {
                            Id=1,
                            Guid=System.Guid.NewGuid(),
                            Name = "record1ForArtist2"
                        },
                        new Record
                        {
                            Id=2,
                            Guid=System.Guid.NewGuid(),
                            Name = "record2ForArtist2"
                        },
                        new Record
                        {
                            Id=3,
                            Guid=System.Guid.NewGuid(),
                            Name = "record3ForArtist2"
                        }
                    }
                },
                  new Artist
                {
                    Id = 3,
                    Guid = System.Guid.NewGuid(),
                    Name = "test1236ffff",
                    Discography = new System.Collections.Generic.List<Record>
                    {
                        new Record
                        {
                            Id=1,
                            Guid=System.Guid.NewGuid(),
                            Name = "record1ForArtist3"
                        },
                        new Record
                        {
                            Id=2,
                            Guid=System.Guid.NewGuid(),
                            Name = "record2ForArtist3"
                        },
                        new Record
                        {
                            Id=3,
                            Guid=System.Guid.NewGuid(),
                            Name = "record3ForArtist3"
                        }
                    }
                }
            });

            await DbContext.SaveChangesAsync();
        }

        public PocContext DbContext { get; private set; }
    }
}
