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
    public sealed class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(x => x.Evalution)
                   .IsRequired();

            builder.HasOne(x => x.Course)
                   .WithMany(x => x.Reviews)
                   .HasForeignKey(x => x.CourseId)
                   .HasConstraintName("FK_Course_Review");

            builder.HasOne(x => x.Student)
                   .WithMany(x => x.Reviews)
                   .HasForeignKey(x => x.StudentId)
                   .HasConstraintName("FK_Student_Review");
        }
    }
}
