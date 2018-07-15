using Dzaba.Randomizer.DataAccess.Contracts;
using Dzaba.Randomizer.DataAccess.Contracts.Dal;
using Dzaba.Randomizer.DataAccess.EntityFramework.Configuration;
using Dzaba.Randomizer.DataAccess.EntityFramework.Dal;
using Dzaba.Randomizer.Utils;
using Microsoft.EntityFrameworkCore;
using Ninject;
using Ninject.Activation;

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

            container.RegisterTransient<IModelConfiguration, EntityModelConfiguration>();
            container.RegisterTransient<IModelConfiguration, EnvironmentConfiguration>();
            container.RegisterTransient<IModelConfiguration, EnvironmentUserConfiguration>();
            container.RegisterTransient<IModelConfiguration, GroupConfiguration>();
            container.RegisterTransient<IModelConfiguration, RandomizationConfiguration>();
            container.RegisterTransient<IModelConfiguration, RandomizationEntityConfiguration>();
            container.RegisterTransient<IModelConfiguration, RoleConfiguration>();
            container.RegisterTransient<IModelConfiguration, UserConfiguration>();

            container.RegisterTransient<IDbInitializer, DbInitalizer>();
            container.RegisterTransient<IEnvironmentDal, EnvironmentDal>();
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
