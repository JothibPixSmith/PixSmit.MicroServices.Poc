using Moq;
using PixSmith.MicroServices.Infrastructure.Repositories.Interfaces;
using System.Threading.Tasks;

namespace PixSmith.MicroServices.Services.UnitTests.Context
{
    public class ArtistServiceTestContext
    {
        private Mock<IArtistRepository> repositoryMock;


        protected void GivenRepositoryMock()
        {
            repositoryMock = new Mock<IArtistRepository>();
        }

        protected IArtistRepository ArtistRepository => repositoryMock.Object;
    }
}
