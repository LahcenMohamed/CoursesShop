using CoursesShop.Data.Identity;

namespace CoursesShop.Service.UserServices.Interfaces
{
    public interface ICurrentUserService
    {
        public Task<ApplicationUser> GetUserAsync();
        public int GetUserId();
        public Task<List<string>> GetCurrentUserRolesAsync();
    }
}
