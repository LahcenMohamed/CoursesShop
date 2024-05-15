using CoursesShop.Data.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursesShop.Infrastructure.Configurations
{
    public sealed class UserRefreshTokenConfiguration : IEntityTypeConfiguration<UserRefreshToken>
    {
        public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {
            builder.Property(x => x.Id).HasDefaultValue(Guid.NewGuid().ToString());

            builder.HasOne(x => x.ApplicationUser)
                   .WithMany(x => x.UserRefreshTokens)
                   .HasForeignKey(x => x.ApplicationUserId);
        }
    }
}
