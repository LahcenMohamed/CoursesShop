using CoursesShop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesShop.Infrastructure.Configurations
{
    public sealed class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {

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
            builder.HasOne(x => x.Teacher)
                   .WithMany(x => x.Courses)
                   .HasForeignKey(x => x.TeacherId)
                   .HasConstraintName("FK_Teacher_Course");
        }
    }
}
