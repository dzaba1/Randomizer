using Dzaba.Randomizer.Utils;
using Ninject;

namespace Dzaba.Randomizer.DataAccess.EntityFramework.Sqlite
{
    public static class Bootstrapper
    {
        public static void RegisterSqlite(this IKernel container)
        {
            Require.NotNull(container, nameof(container));

            container.RegisterTransient<IEntityFrameworkProvider, SqliteProvider>();
        }
    }
}
