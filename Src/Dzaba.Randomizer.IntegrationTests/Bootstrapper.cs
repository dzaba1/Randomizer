using Dzaba.Randomizer.DataAccess.Contracts;
using Dzaba.Randomizer.DataAccess.EntityFramework;
using Dzaba.Randomizer.DataAccess.EntityFramework.Sqlite;
using Dzaba.Randomizer.Utils;
using Ninject;

namespace Dzaba.Randomizer.IntegrationTests
{
    internal static class Bootstrapper
    {
        public static IKernel CreateContainer()
        {
            var container = new StandardKernel();
            container.RegisterEntityFrameworkDataAccess();
            container.RegisterSqlite();
            container.RegisterIntegrationTests();

            return container;
        }

        private static void RegisterIntegrationTests(this IKernel container)
        {
            container.RegisterTransient<IConnectionStringProvider, ConnectionStringProvider>();
        }
    }
}
