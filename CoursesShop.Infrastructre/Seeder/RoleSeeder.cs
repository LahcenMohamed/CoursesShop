using Microsoft.AspNetCore.Identity;

namespace CoursesShop.Infrastructure.Seeder
{
    public static class RoleSeeder
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole
                {
                    Name = "Admin"
                });

                await roleManager.CreateAsync(new IdentityRole
                {
                    Name = "Student"
                });

                await roleManager.CreateAsync(new IdentityRole
                {
                    Name = "Teacher"
                });
            }
        }
    }
}
