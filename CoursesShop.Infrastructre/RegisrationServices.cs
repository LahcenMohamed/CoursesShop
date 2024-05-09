using CoursesShop.Data.Identity;
using ECommerceCourse.DataAccess.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoursesShop.Infrastructure
{
    public static class RegisrationServices
    {
        public static IServiceCollection AddRegisrationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CoursesShopDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ECommerceCourseDbConnectionString")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;

                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_ ";

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            })
                .AddEntityFrameworkStores<CoursesShopDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
