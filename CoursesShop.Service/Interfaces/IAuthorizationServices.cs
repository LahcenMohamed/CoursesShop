using Microsoft.AspNetCore.Identity;

namespace CoursesShop.Service.Interfaces
{
    public interface IAuthorizationServices
    {
        public bool isExistName(string Name);
        public Task<string> Add(IdentityRole identityRole);
    }
}
