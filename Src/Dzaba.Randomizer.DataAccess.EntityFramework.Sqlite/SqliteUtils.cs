using Dzaba.Randomizer.Utils;

namespace Dzaba.Randomizer.DataAccess.EntityFramework.Sqlite
{
    public static class SqliteUtils
    {
        public static string CreateConnectionString(string location)
        {
            Require.NotEmpty(location, nameof(location));

            return $"Data Source={location}";
        }
    }
}
