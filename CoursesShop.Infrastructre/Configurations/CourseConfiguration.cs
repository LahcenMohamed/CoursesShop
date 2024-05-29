using CoursesShop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursesShop.Infrastructure.Configurations
{
    public sealed class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(x => x.Id).HasDefaultValue(Guid.NewGuid().ToString());

            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(x => x.Description)
                   .IsRequired();

            builder.Property(x => x.Price)
                   .IsRequired();

            builder.Property(x => x.ReviewsAverge)
                   .IsRequired()
                   .HasDefaultValue(0m);

            builder.Property(x => x.ImageUrl)
                   .HasDefaultValue("/Images/Courses/DefultCourse.jpg");

            builder.HasOne(x => x.Teacher)
                   .WithMany(x => x.Courses)
                   .HasForeignKey(x => x.TeacherId)
                   .HasConstraintName("FK_Teacher_Course");
        }
    }
}
