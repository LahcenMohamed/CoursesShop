using CoursesShop.Service.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CoursesShop.Service.Implementations
{
    public sealed class AutorizationServices(RoleManager<IdentityRole> roleManager) : IAuthorizationServices
    {
        private readonly RoleManager<IdentityRole> _roleManager = roleManager;

        public async Task<string> Add(IdentityRole identityRole)
        {
            var result = await _roleManager.CreateAsync(identityRole);
            if (result.Succeeded)
            {
                return identityRole.Id;
            }
            return "Error:" + result.Errors.First().Description;
        }

        public bool isExistName(string Name)
        {
            return _roleManager.Roles.Any(r => r.Name == Name);
        }
    }
}
