using Dzaba.Randomizer.DataAccess.Contracts.Model;
using Dzaba.Randomizer.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dzaba.Randomizer.DataAccess.EntityFramework.Configuration
{
    internal sealed class RandomizationConfiguration : EntityConfiguration<Randomization>
    {
        protected override void Configure(EntityTypeBuilder<Randomization> builder)
        {
            Require.NotNull(builder, nameof(builder));

            builder.HasOne(p => p.Invoker)
                .WithMany(p => p.Randomizations)
                .HasForeignKey(p => p.IvokerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Winner)
                .WithMany(p => p.Wins)
                .HasForeignKey(p => p.WinnerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
