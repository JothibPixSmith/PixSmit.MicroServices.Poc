using PixSmith.MicroServices.Domain;

namespace PixSmith.MicroServices.Services.Interfaces
{
    public interface IArtistService
    {
        Task<Artist> Get(Guid guid);

        Task<Artist> Save(Artist artist);
        Task Delete(Guid guid);
    }
}
