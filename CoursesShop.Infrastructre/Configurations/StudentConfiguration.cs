using CoursesShop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursesShop.Infrastructure.Configurations
{
    public sealed class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(x => x.Id).HasDefaultValue(Guid.NewGuid().ToString());
            builder.Property(x => x.FullName)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(100);

        }
    }
}
