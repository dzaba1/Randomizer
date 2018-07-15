using Dzaba.Randomizer.DataAccess.Contracts.Model;
using Dzaba.Randomizer.Utils;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dzaba.Randomizer.DataAccess.EntityFramework.Configuration
{
    internal sealed class RoleConfiguration : EntityConfiguration<Role>
    {
        protected override void Configure(EntityTypeBuilder<Role> builder)
        {
            Require.NotNull(builder, nameof(builder));

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
