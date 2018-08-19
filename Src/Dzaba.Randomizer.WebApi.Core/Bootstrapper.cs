using Dzaba.Randomizer.DataAccess.EntityFramework;
using Dzaba.Randomizer.DataAccess.EntityFramework.Sqlite;
using Dzaba.Randomizer.Utils;
using Dzaba.Randomizer.WebApi.Jwt;
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
            RegisterAll(container);

            return container.Kernel;
        }

        public static void RegisterAll(this Containers container)
        {
            container.RegsiterUtils();
            container.RegisterEntityFrameworkDataAccess();
            container.RegisterSqlite();
            container.RegisterWebApi();
            container.RegisterJwtAuth();

            container.ServiceCollection.CopyTo(container.Kernel);
        }

        private static void RegisterWebApi(this Containers container)
        {
            container.Kernel.RegisterSingletonInstance<IServiceProvider>(container.Kernel);

            container.ServiceCollection.AddMvc();
        }
    }
}
