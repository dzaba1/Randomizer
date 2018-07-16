using Dzaba.Randomizer.DataAccess.EntityFramework;
using Dzaba.Randomizer.DataAccess.EntityFramework.Sqlite;
using Dzaba.Randomizer.Utils;
using Microsoft.Extensions.DependencyInjection;
using Ninject;
using System;

namespace Dzaba.Randomizer.WebApi.Core
{
    public static class Bootstrapper
    {
        public static IKernel CreateContainer()
        {
            var container = new Containers();
            container.RegisterEntityFrameworkDataAccess();
            container.RegisterSqlite();
            container.RegisterWebApi();

            container.ServiceCollection.CopyTo(container.Kernel);

            return container.Kernel;
        }

        private static void RegisterWebApi(this Containers container)
        {
            container.Kernel.RegisterSingletonInstance<IServiceProvider>(container.Kernel);

            container.ServiceCollection.AddMvc();
        }
    }
}
