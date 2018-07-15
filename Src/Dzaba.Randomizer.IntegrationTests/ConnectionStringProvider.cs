using Dzaba.Randomizer.DataAccess.Contracts;
using Dzaba.Randomizer.DataAccess.EntityFramework.Sqlite;

namespace Dzaba.Randomizer.IntegrationTests
{
    internal sealed class ConnectionStringProvider : IConnectionStringProvider
    {
        public string GetConnectionString()
        {
            return SqliteUtils.CreateConnectionString(DbUtils.Location);
        }
    }
}