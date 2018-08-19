using Dzaba.Randomizer.Contracts;
using Dzaba.Randomizer.DataAccess.Contracts;
using Dzaba.Randomizer.DataAccess.Contracts.Dal;
using Dzaba.Randomizer.DataAccess.Contracts.Model;
using Dzaba.Randomizer.WebApi.Core.Controllers;
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

        protected async Task<UserInfo> CreateTestUserAsync()
        {
            var controller = Container.Get<AuthController>();
            var result = await controller.Register(new RegisterUser
            {
                Email = "Test@test.com",
                Password = "Password1"
            });
            return result.Content<UserInfo>();
        }
    }
}
