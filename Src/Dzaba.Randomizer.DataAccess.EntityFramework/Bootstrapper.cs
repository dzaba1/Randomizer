using Dzaba.Randomizer.DataAccess.Contracts;
using Dzaba.Randomizer.DataAccess.Contracts.Dal;
using Dzaba.Randomizer.DataAccess.EntityFramework.Configuration;
using Dzaba.Randomizer.DataAccess.EntityFramework.Dal;
using Dzaba.Randomizer.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ninject;

namespace Dzaba.Randomizer.DataAccess.EntityFramework
{
    public static class Bootstrapper
    {
        public static void RegisterEntityFrameworkDataAccess(this Containers container)
        {
            Require.NotNull(container, nameof(container));

            container.ServiceCollection.AddDbContext<DatabaseContext>(b => OptionsHandler(container.Kernel, b), ServiceLifetime.Transient, ServiceLifetime.Singleton);

            container.Kernel.RegisterFactoryMethod<DatabaseContext>();

            container.Kernel.RegisterTransient<IModelConfiguration, EntityModelConfiguration>();
            container.Kernel.RegisterTransient<IModelConfiguration, EnvironmentConfiguration>();
            container.Kernel.RegisterTransient<IModelConfiguration, EnvironmentUserConfiguration>();
            container.Kernel.RegisterTransient<IModelConfiguration, GroupConfiguration>();
            container.Kernel.RegisterTransient<IModelConfiguration, RandomizationConfiguration>();
            container.Kernel.RegisterTransient<IModelConfiguration, RandomizationEntityConfiguration>();
            container.Kernel.RegisterTransient<IModelConfiguration, RoleConfiguration>();
            container.Kernel.RegisterTransient<IModelConfiguration, UserConfiguration>();

            container.Kernel.RegisterTransient<IDbInitializer, DbInitalizer>();
            container.Kernel.RegisterTransient<IEnvironmentDal, EnvironmentDal>();
        }

        private static void OptionsHandler(IKernel container, DbContextOptionsBuilder builder)
        {
            var provider = container.Get<IEntityFrameworkProvider>();
            var connectionStringProvider = container.Get<IConnectionStringProvider>();

            builder.UseLazyLoadingProxies();
            provider.Register(connectionStringProvider.GetConnectionString(), builder);
        }
    }
}
