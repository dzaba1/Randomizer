using Microsoft.EntityFrameworkCore;

namespace Dzaba.Randomizer.DataAccess.EntityFramework.Configuration
{
    public interface IModelConfiguration
    {
        void Configure(ModelBuilder modelBuilder);
    }
}
