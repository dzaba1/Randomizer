using Microsoft.EntityFrameworkCore;

namespace Dzaba.Randomizer.DataAccess.EntityFramework
{
    public interface IEntityFrameworkProvider
    {
        void Register(string connectionString, DbContextOptionsBuilder builder);
    }
}