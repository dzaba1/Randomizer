using Dzaba.Randomizer.DataAccess.Contracts;
using Dzaba.Randomizer.Utils;
using Ninject;

namespace Dzaba.Randomizer.IntegrationTests
{
    internal static class Bootstrapper
    {
        public static IKernel CreateContainer()
        {
            var container = WebApi.Core.Bootstrapper.CreateContainer();
            container.RegisterIntegrationTests();

            return container;
        }

        private static void RegisterIntegrationTests(this IKernel container)
        {
            container.RegisterTransient<IConnectionStringProvider, ConnectionStringProvider>();
        }
    }
}
