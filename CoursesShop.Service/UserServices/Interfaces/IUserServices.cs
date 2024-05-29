using CoursesShop.Data.Identity;

namespace CoursesShop.Service.UserServices.Interfaces
{
    public interface IUserServices
    {
        public bool isUser(string userName);
        public bool isExistEmail(string Email);
        public bool isExistId(string Id);
        public IQueryable<ApplicationUser> UsersFilltering(string search);
        public IQueryable<ApplicationUser> GetAllAsQueryable();
        public Task<string> DeleteAsync(string id);
        public Task<string> ChangePassword(string Id, string currentPassword, string newPassword);
        public Task<List<ApplicationUser>> GetAll();
        public Task<string> Add(ApplicationUser applicationUser, string password, string type = "Admin");
        public Task<ApplicationUser> GetById(string Id);
        public Task<ApplicationUser> GetByUserName(string UserName);
        public Task<string> ConfirmEmail(string userId, string code);
        public Task<string> SendResetPasswordCode(string userName);
        public Task<string> ResetPassword(string userName, string password, string code);


    }
}
