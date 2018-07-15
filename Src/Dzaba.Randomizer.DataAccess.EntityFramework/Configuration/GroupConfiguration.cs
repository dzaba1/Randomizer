using Dzaba.Randomizer.DataAccess.Contracts.Model;
using Dzaba.Randomizer.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dzaba.Randomizer.DataAccess.EntityFramework.Configuration
{
    internal sealed class GroupConfiguration : EntityConfiguration<Group>
    {
        protected override void Configure(EntityTypeBuilder<Group> builder)
        {
            Require.NotNull(builder, nameof(builder));

            builder.HasIndex(p => p.Name);
            builder.HasOne(p => p.Environment)
                .WithMany(p => p.Groups)
                .HasForeignKey(p => p.EnvironmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
