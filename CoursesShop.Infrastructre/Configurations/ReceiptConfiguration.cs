using CoursesShop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursesShop.Infrastructure.Configurations
{
    public sealed class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            builder.Property(e => e.DateAndTime)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.Price)
                   .IsRequired()
                   .HasColumnType("money");

            builder.HasOne(x => x.Course)
                   .WithMany(x => x.Receipts)
                   .HasForeignKey(x => x.CourseId)
                   .HasConstraintName("FK_Course_Receipt");

            builder.HasOne(x => x.Student)
                   .WithMany(x => x.Receipts)
                   .HasForeignKey(x => x.StudentId)
                   .HasConstraintName("FK_Student_Receipt");
        }
    }
}
