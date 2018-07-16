using Dzaba.Randomizer.Utils;
using Ninject;

namespace Dzaba.Randomizer.DataAccess.EntityFramework.Sqlite
{
    public static class Bootstrapper
    {
        public static void RegisterSqlite(this Containers container)
        {
            Require.NotNull(container, nameof(container));

            container.Kernel.RegisterTransient<IEntityFrameworkProvider, SqliteProvider>();
        }
    }
}
