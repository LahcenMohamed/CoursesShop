using CoursesShop.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoursesShop.Infrastructure.Seeder
{
    public static class UserSeeder
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var isVoid = await userManager.Users.AnyAsync();
            if (!isVoid)
            {
                ApplicationUser user = new()
                {
                    UserName = "Uerk",
                    Email = "Lahcen_Mohamed@outlook.com",
                    EmailConfirmed = true,
                    TypeId = null
                };

                await userManager.CreateAsync(user, "0558892473");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
