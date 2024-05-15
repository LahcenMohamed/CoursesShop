using CoursesShop.Data.Identity;

namespace CoursesShop.Service.Interfaces
{
    public interface IUserServices
    {
        public bool isUser(string userName);
        public bool isExistId(string Id);
        public IQueryable<ApplicationUser> UsersFilltering(string search);
        public IQueryable<ApplicationUser> GetAllAsQueryable();
        public Task<string> DeleteAsync(string id);
        public Task<string> ChangePassword(string Id, string currentPassword, string newPassword);
        public Task<List<ApplicationUser>> GetAll();
        public Task<string> Add(ApplicationUser applicationUser, string password);
        public Task<ApplicationUser> GetById(string Id);
        public Task<ApplicationUser> GetByUserName(string UserName);
    }
}
