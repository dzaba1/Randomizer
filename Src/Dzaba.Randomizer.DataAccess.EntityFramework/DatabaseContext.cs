using Dzaba.Randomizer.DataAccess.Contracts.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dzaba.Randomizer.DataAccess.EntityFramework
{
    internal sealed class DatabaseContext : IdentityDbContext<User, Role, long>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
