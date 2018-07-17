using Dzaba.Randomizer.DataAccess.Contracts;
using Dzaba.Randomizer.DataAccess.Contracts.Dal;
using Ninject;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Dzaba.Randomizer.IntegrationTests
{
    public class IntegrationTestFixutre<T>
    {
        protected IKernel Container { get; private set; }

        [SetUp]
        public async Task Setup()
        {
            DbUtils.Delete();
            Container = Bootstrapper.CreateContainer();
            await InitializeDbAsync();
        }

        [TearDown]
        public void Cleanup()
        {
            Container.Dispose();
            DbUtils.Delete();
        }

        protected T CreateSut()
        {
            return Container.Get<T>();
        }

        protected async Task InitializeDbAsync()
        {
            var sut = Container.Get<IDbInitializer>();
            await sut.InitializeAsync();
        }

        protected Task<long> CreateTestUserAsync()
        {
            var userDal = Container.Get<IUserDal>();
            return userDal.CreateAsync("Test", "aaa");
        }
    }
}
