using Dzaba.Randomizer.DataAccess.EntityFramework;
using Dzaba.Randomizer.DataAccess.EntityFramework.Sqlite;
using Dzaba.Randomizer.Utils;
using Ninject;
using System;

namespace Dzaba.Randomizer.WebApi.Core
{
    public static class Bootstrapper
    {
        public static IKernel CreateContainer()
        {
            var container = new StandardKernel();
            container.RegisterEntityFrameworkDataAccess();
            container.RegisterSqlite();
            container.RegisterWebApi();

            return container;
        }

        private static void RegisterWebApi(this IKernel container)
        {
            container.RegisterSingletonInstance<IServiceProvider>(container);
        }
    }
}
