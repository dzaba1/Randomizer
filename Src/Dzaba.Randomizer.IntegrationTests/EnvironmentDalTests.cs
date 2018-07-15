using Dzaba.Randomizer.DataAccess.Contracts.Dal;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dzaba.Randomizer.IntegrationTests
{
    [TestFixture]
    public class EnvironmentDalTests : IntegrationTestFixutre<IEnvironmentDal>
    {
        [Test]
        public async Task Create_WhenEntitiesAreCreated_ThenThoseCanBeAccessed()
        {
            await InitializeDbAsync();

            var sut = CreateSut();

            var ids = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                var id = await sut.Create(i.ToString(), 1);
                ids.Add(id);
            }

            var all = await sut.GetAllAsync();

            all.Length.Should().Be(4);
            foreach (var id in ids)
            {
                var entity = await sut.GetAsync(id);
                entity.Id.Should().Be(id);
                entity.Name.Should().Be(id.ToString());
            }
        }
    }
}
