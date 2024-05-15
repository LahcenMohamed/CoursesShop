using CoursesShop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursesShop.Infrastructure.Configurations
{
    public sealed class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(x => x.Id).HasDefaultValue(Guid.NewGuid().ToString());
            builder.Property(x => x.imageUrl)
                   .IsRequired()
                   .HasDefaultValue("/Images/Teachers/User.png");
            builder.Property(x => x.FullName)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(x => x.Email)
                    .IsRequired()
                    .HasMaxLength(100);

        }
    }
}
