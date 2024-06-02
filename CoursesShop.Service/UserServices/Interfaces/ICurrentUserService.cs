using CoursesShop.Data.Identity;

namespace CoursesShop.Service.UserServices.Interfaces
{
    public interface ICurrentUserService
    {
        public Task<ApplicationUser> GetUserAsync();
        public string GetUserId();
        public string GetTypeId();
        public Task<List<string>> GetCurrentUserRolesAsync();
    }
}
