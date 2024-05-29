using Microsoft.AspNetCore.Identity;

namespace CoursesShop.Service.UserServices.Interfaces
{
    public interface IAuthorizationServices
    {
        public bool isExistName(string Name);
        public Task<string> Add(IdentityRole identityRole);
    }
}
