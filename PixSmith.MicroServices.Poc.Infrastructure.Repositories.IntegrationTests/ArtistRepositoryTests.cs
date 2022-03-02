using PixSmith.MicroServices.Infrastructure.Repositories.IntegrationTests.Context;
using System.Threading.Tasks;
using Xunit;

namespace PixSmith.MicroServices.Infrastructure.Repositories.IntegrationTests
{
    public class ArtistRepositoryTests : ArtistRepositoryContext
    {
        public ArtistRepositoryTests()
        {
        }

        [Fact]
        public async Task RetrieveShortestStringRawSqlTest()
        {
            await GivenSQLLiteTestDB();


        }
    }
}