using Dzaba.Randomizer.Utils;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dzaba.Randomizer.DataAccess.EntityFramework.Configuration
{
    internal sealed class EnvironmentConfiguration : EntityConfiguration<Contracts.Model.Environment>
    {
        protected override void Configure(EntityTypeBuilder<Contracts.Model.Environment> builder)
        {
            Require.NotNull(builder, nameof(builder));

            builder.HasIndex(p => p.Name)
                .IsUnique();
        }
    }
}
