using Dzaba.Randomizer.DataAccess.Contracts;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Dzaba.Randomizer.IntegrationTests
{
    [TestFixture]
    public class DbInitalizerTests : IntegrationTestFixutre<IDbInitializer>
    {
        [Test]
        public async Task InitializeAsync_WhenCalled_ThenItMakesADb()
        {
            var sut = CreateSut();
            await sut.InitializeAsync();
        }
    }
}
