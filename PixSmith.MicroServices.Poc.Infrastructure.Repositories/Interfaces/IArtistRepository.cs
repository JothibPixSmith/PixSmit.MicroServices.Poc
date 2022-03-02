using PixSmith.MicroServices.Domain;

namespace PixSmith.MicroServices.Infrastructure.Repositories.Interfaces
{
    public interface IArtistRepository
    {
        Task<Artist> Get(Guid guid);

        Task<Artist> Insert(Artist artist);

        Task<Artist> Update(Artist artist);
        Task Delete(Guid guid);
    }
}
