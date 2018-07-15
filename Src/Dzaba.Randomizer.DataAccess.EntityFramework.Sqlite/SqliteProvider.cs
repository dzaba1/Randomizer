using Dzaba.Randomizer.Utils;
using Microsoft.EntityFrameworkCore;

namespace Dzaba.Randomizer.DataAccess.EntityFramework.Sqlite
{
    internal sealed class SqliteProvider : IEntityFrameworkProvider
    {
        public void Register(string connectionString, DbContextOptionsBuilder optionsBuilder)
        {
            Require.NotWhiteSpace(connectionString, nameof(connectionString));
            Require.NotNull(optionsBuilder, nameof(optionsBuilder));

            optionsBuilder.UseSqlite(connectionString);
        }
    }
}
