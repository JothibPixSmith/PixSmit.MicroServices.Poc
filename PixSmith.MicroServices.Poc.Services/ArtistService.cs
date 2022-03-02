using PixSmith.MicroServices.Domain;
using PixSmith.MicroServices.Infrastructure.Repositories.Interfaces;
using PixSmith.MicroServices.Services.Interfaces;

namespace PixSmith.MicroServices.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository repository;

        public ArtistService(IArtistRepository repository)
        {
            this.repository = repository;
        }

        public async Task Delete(Guid guid)
        {
            await this.repository.Delete(guid);
        }

        public async Task<Artist> Get(Guid guid)
        {
            return await this.repository.Get(guid);
        }

        public async Task<Artist> Save(Artist artist)
        {
            if (artist.Guid != Guid.Empty)
            {
                this.AssignGuidToRecords(artist.Discography);

                artist = await this.repository.Update(artist);
            }
            else
            {
                artist.Guid = Guid.NewGuid();

                this.AssignGuidToRecords(artist.Discography);

                artist = await this.repository.Insert(artist);
            }

            return artist;
        }

        private void AssignGuidToRecords(List<Record> records)
        {
            foreach (var record in records)
            {
                if (record.Guid == Guid.Empty)
                {
                    record.Guid = Guid.NewGuid();
                }
            }
        }
    }
}
