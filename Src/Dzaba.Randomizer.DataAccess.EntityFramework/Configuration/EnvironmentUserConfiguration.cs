using Dzaba.Randomizer.DataAccess.Contracts.Model;
using Dzaba.Randomizer.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dzaba.Randomizer.DataAccess.EntityFramework.Configuration
{
    internal sealed class EnvironmentUserConfiguration : EntityConfiguration<EnvironmentUser>
    {
        protected override void Configure(EntityTypeBuilder<EnvironmentUser> builder)
        {
            Require.NotNull(builder, nameof(builder));

            builder.HasOne(p => p.Environment)
                .WithMany(p => p.Users)
                .HasForeignKey(p => p.EnvironmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.User)
                .WithMany(p => p.Environments)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
