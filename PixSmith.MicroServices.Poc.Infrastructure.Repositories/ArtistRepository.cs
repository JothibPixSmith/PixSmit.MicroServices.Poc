using Microsoft.EntityFrameworkCore;
using PixSmith.MicroServices.Domain;
using PixSmith.MicroServices.Infrastructure.Database;
using PixSmith.MicroServices.Infrastructure.Repositories.Interfaces;

namespace PixSmith.MicroServices.Infrastructure.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly PocContext context;

        public ArtistRepository(PocContext context)
        {
            this.context = context;
        }

        public async Task Delete(Guid guid)//going to have to find a way to get the db Id without getting the object
        {
            var currentArtist = this.context.Artists
                .Include(x => x.Discography)
                .Single(x => x.Guid == guid);

            this.context.Records.RemoveRange(currentArtist.Discography);

            this.context.Artists.Remove(currentArtist);

            await this.context.SaveChangesAsync();
        }

        public async Task<Artist> Get(Guid guid)
        {
            return await this.context.Artists
                .Include(x => x.Discography)
                .SingleAsync(x => x.Guid == guid);
        }

        public async Task<Artist> Insert(Artist artist)
        {
            await this.context.Artists.AddAsync(artist);

            await this.context.SaveChangesAsync();

            return artist;

        }

        public async Task<Artist> Update(Artist artist)
        {
            this.context.Attach(artist);

            await this.context.SaveChangesAsync();

            return artist;
        }
    }
}
