using Dzaba.Randomizer.DataAccess.Contracts.Model;
using Dzaba.Randomizer.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dzaba.Randomizer.DataAccess.EntityFramework.Configuration
{
    internal sealed class RandomizationEntityConfiguration : EntityConfiguration<RandomizationEntity>
    {
        protected override void Configure(EntityTypeBuilder<RandomizationEntity> builder)
        {
            Require.NotNull(builder, nameof(builder));

            builder.HasKey(p => new { p.EntityId, p.RandomizationId });

            builder.HasOne(p => p.Entity)
                .WithMany(p => p.Randomizations)
                .HasForeignKey(p => p.EntityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Randomization)
                .WithMany(p => p.Entites)
                .HasForeignKey(p => p.RandomizationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
