using Dzaba.Randomizer.DataAccess.Contracts;
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
    }
}
