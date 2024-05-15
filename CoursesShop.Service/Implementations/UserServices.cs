using CoursesShop.Data.Identity;
using CoursesShop.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoursesShop.Service.Implementations
{
    public sealed class UserServices(UserManager<ApplicationUser> userManager) : IUserServices
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;

        public async Task<string> Add(ApplicationUser applicationUser, string password)
        {
            var result = await _userManager.CreateAsync(applicationUser, password);
            if (result.Succeeded)
            {
                return applicationUser.Id;
            }
            return "Error: " + result.Errors.First().Description;
        }

        public async Task<string> ChangePassword(string Id, string currentPassword, string newPassword)
        {
            var user = await GetById(Id);
            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

            if (result.Succeeded)
            {
                return "Succeeded";
            }
            return result.Errors.First().Description;
        }

        public async Task<string> DeleteAsync(string id)
        {
            var user = await GetById(id);
            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return "Succeeded";
            }
            return result.Errors.First().Description;

        }


        public async Task<List<ApplicationUser>> GetAll()
        {
            return await _userManager.Users.Select(x => new ApplicationUser { Id = x.Id, UserName = x.UserName, Email = x.Email }).ToListAsync();
        }
        public IQueryable<ApplicationUser> GetAllAsQueryable()
        {
            return _userManager.Users.Select(x => new ApplicationUser { Id = x.Id, UserName = x.UserName, Email = x.Email });
        }

        public async Task<ApplicationUser> GetById(string Id)
        {
            return await _userManager.FindByIdAsync(Id);
        }
        public async Task<ApplicationUser> GetByUserName(string UserName)
        {
            return await _userManager.FindByNameAsync(UserName);
        }

        public bool isExistId(string Id)
        {
            return _userManager.Users.Any(x => x.Id == Id);
        }

        public bool isUser(string userName)
        {
            return _userManager.Users.Any(u => u.UserName == userName);
        }

        public IQueryable<ApplicationUser> UsersFilltering(string search)
        {
            return _userManager.Users.Where(x => x.UserName.Contains(search) || x.Email.Contains(search));
        }
    }
}
