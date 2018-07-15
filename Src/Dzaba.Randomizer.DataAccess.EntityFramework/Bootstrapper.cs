using Dzaba.Randomizer.DataAccess.Contracts;
using Dzaba.Randomizer.Utils;
using Microsoft.EntityFrameworkCore;
using Ninject;
using Ninject.Activation;
using System;

namespace Dzaba.Randomizer.DataAccess.EntityFramework
{
    public static class Bootstrapper
    {
        public static void RegisterEntityFrameworkDataAccess(this IKernel container)
        {
            Require.NotNull(container, nameof(container));

            container.Bind<DatabaseContext>()
                .ToSelf()
                .InTransientScope();

            container.Bind<DbContextOptions<DatabaseContext>>()
                .ToMethod(BuildOptions)
                .InSingletonScope();

            container.RegisterFactoryMethod<DatabaseContext>();
        }

        private static DbContextOptions<DatabaseContext> BuildOptions(IContext context)
        {
            var builder = new DbContextOptionsBuilder<DatabaseContext>();

            var provider = context.Kernel.Get<IEntityFrameworkProvider>();
            var connectionStringProvider = context.Kernel.Get<IConnectionStringProvider>();

            builder.UseLazyLoadingProxies();
            provider.Register(connectionStringProvider.GetConnectionString(), builder);

            return builder.Options;
        }
    }
}
