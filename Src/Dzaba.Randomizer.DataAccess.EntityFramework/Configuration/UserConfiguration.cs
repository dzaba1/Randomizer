using Dzaba.Randomizer.DataAccess.Contracts.Model;
using Dzaba.Randomizer.Utils;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dzaba.Randomizer.DataAccess.EntityFramework.Configuration
{
    internal sealed class UserConfiguration : EntityConfiguration<User>
    {
        protected override void Configure(EntityTypeBuilder<User> builder)
        {
            Require.NotNull(builder, nameof(builder));

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
