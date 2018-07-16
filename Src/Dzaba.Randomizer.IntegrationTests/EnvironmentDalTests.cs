using Dzaba.Randomizer.DataAccess.Contracts.Dal;
using FluentAssertions;
using Ninject;
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
            var userDal = Container.Get<IUserDal>();
            var creatorId = await userDal.CreateAsync("Test", "aaa");

            var sut = CreateSut();

            var ids = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                var id = await sut.Create(i.ToString(), creatorId);
                ids.Add(id);
            }

            var all = await sut.GetAllAsync();

            all.Length.Should().Be(4);
            foreach (var id in ids)
            {
                var entity = await sut.GetAsync(id);
                entity.Id.Should().Be(id);
                entity.Name.Should().NotBeNullOrWhiteSpace();
                entity.Users.Length.Should().Be(1);
                entity.Users[0].Id.Should().Be(creatorId);
            }
        }
    }
}
