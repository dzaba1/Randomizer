using Dzaba.Randomizer.DataAccess.Contracts.Model;
using Dzaba.Randomizer.DataAccess.EntityFramework.Configuration;
using Dzaba.Randomizer.Utils;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Dzaba.Randomizer.DataAccess.EntityFramework
{
    internal sealed class DatabaseContext : IdentityDbContext<User, Role, long>
    {
        private readonly IModelConfiguration[] modelConfigurations;

        public DatabaseContext(DbContextOptions<DatabaseContext> options,
            IEnumerable<IModelConfiguration> modelConfigurations)
            : base(options)
        {
            Require.NotNull(modelConfigurations, nameof(modelConfigurations));

            this.modelConfigurations = modelConfigurations.ToArray();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var configuration in modelConfigurations)
            {
                configuration.Configure(builder);
            }
        }

        public DbSet<Entity> Entities { get; set; }

        public DbSet<Environment> Environments { get; set; }

        public DbSet<EnvironmentUser> EnvironmentUsers { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Randomization> Randomizations { get; set; }

        public DbSet<RandomizationEntity> RandomizationEntities { get; set; }
    }
}
