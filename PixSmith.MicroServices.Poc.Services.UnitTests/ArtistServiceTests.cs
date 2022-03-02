using PixSmith.MicroServices.Services.UnitTests.Context;
using System.Threading.Tasks;
using Xunit;

namespace PixSmith.MicroServices.Services.UnitTests
{
    public class ArtistServiceTests : ArtistServiceTestContext
    {
        public ArtistServiceTests()
        {
            GivenRepositoryMock();
        }

        [Fact]
        public async Task TestArtistService1()
        {
        }

    }
}