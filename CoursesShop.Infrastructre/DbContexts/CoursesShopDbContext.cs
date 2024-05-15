using CoursesShop.Data.Entities;
using CoursesShop.Data.Identity;
using CoursesShop.Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ECommerceCourse.DataAccess.DbContexts
{
    public sealed class CoursesShopDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
        public CoursesShopDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CourseConfiguration());
            builder.ApplyConfiguration(new ReviewConfiguration());
            builder.ApplyConfiguration(new ReceiptConfiguration());
            builder.ApplyConfiguration(new TeacherConfiguration());
            builder.ApplyConfiguration(new StudentConfiguration());
            builder.ApplyConfiguration(new UserRefreshTokenConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
