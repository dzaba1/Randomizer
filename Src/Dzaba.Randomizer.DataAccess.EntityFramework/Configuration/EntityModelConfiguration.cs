using Dzaba.Randomizer.DataAccess.Contracts.Model;
using Dzaba.Randomizer.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dzaba.Randomizer.DataAccess.EntityFramework.Configuration
{
    internal sealed class EntityModelConfiguration : EntityConfiguration<Entity>
    {
        protected override void Configure(EntityTypeBuilder<Entity> builder)
        {
            Require.NotNull(builder, nameof(builder));

            builder.HasIndex(p => p.Name);
            builder.HasOne(p => p.Group)
                .WithMany(p => p.Entities)
                .HasForeignKey(p => p.GroupId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
