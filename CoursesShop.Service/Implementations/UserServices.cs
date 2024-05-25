using CoursesShop.Data.Identity;
using CoursesShop.Infrastructure.DbContexts;
using CoursesShop.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoursesShop.Service.Implementations
{
    public sealed class UserServices(UserManager<ApplicationUser> userManager,
                                     RoleManager<IdentityRole> roleManager,
                                     IEmailServices emailServices,
                                     IHttpContextAccessor httpContextAccessor,
                                     CoursesShopDbContext context) : IUserServices
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly RoleManager<IdentityRole> _roleManager = roleManager;
        private readonly IEmailServices _emailServices = emailServices;
        private readonly CoursesShopDbContext _context = context;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public async Task<string> Add(ApplicationUser applicationUser, string password, string type = "Admin")
        {
            await _context.Database.BeginTransactionAsync();
            var result = await _userManager.CreateAsync(applicationUser, password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(applicationUser, type);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(applicationUser);
                var encodedCode = Uri.EscapeDataString(code);
                var returnUrl = _httpContextAccessor.HttpContext.Request.Scheme +
                                "://" +
                                _httpContextAccessor.HttpContext.Request.Host +
                                $"/api/Authentication/ConfirmEmail?userId={applicationUser.Id}&code={encodedCode}";
                var message = $"To Confirm Email Click Link: <a href='{returnUrl}'>Link Of Confirmation</a>";
                var response = await _emailServices.SendEmailAsync(applicationUser.Email, message, "Confirm Email");
                if (response.Contains("Error"))
                {
                    await _context.Database.RollbackTransactionAsync();
                }
                else
                {
                    await _context.Database.CommitTransactionAsync();
                }
                return response;
            }
            await _context.Database.RollbackTransactionAsync();
            return "Error: " + string.Join(",", result.Errors.Select(x => x.Description));
        }

        public async Task<string> ConfirmEmail(string userId, string code)
        {
            var user = await GetById(userId);
            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                return "Success";
            }
            return string.Join(",", result.Errors.Select(x => x.Description).ToList());
        }

        public async Task<string> ChangePassword(string Id, string currentPassword, string newPassword)
        {
            var user = await GetById(Id);
            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

            if (result.Succeeded)
            {
                return "Succeeded";
            }
            return string.Join(",", result.Errors.Select(x => x.Description));
        }

        public async Task<string> DeleteAsync(string id)
        {
            var user = await GetById(id);
            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return "Succeeded";
            }
            return string.Join(",", result.Errors.Select(x => x.Description));

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

        public bool isExistEmail(string Email)
        {
            return _userManager.Users.Any(x => x.Email == Email);
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

        public async Task<string> SendResetPasswordCode(string userName)
        {
            var applicationUser = await _userManager.FindByNameAsync(userName);
            Random random = new Random();

            applicationUser.Code = random.Next(111111, 1000000).ToString();
            await _userManager.UpdateAsync(applicationUser);
            var message = $"Reset password code is: {applicationUser.Code}";
            var response = await _emailServices.SendEmailAsync(applicationUser.Email, message, "Reset Password");
            return response;

        }

        public async Task<string> ResetPassword(string userName, string password, string code)
        {
            var user = await GetByUserName(userName);
            if (user.Code == code)
            {
                await _userManager.RemovePasswordAsync(user);
                var result = await _userManager.AddPasswordAsync(user, password);
                if (result.Succeeded)
                {
                    user.Code = null;
                    await _userManager.UpdateAsync(user);
                    return "Success";
                }
                return string.Join(',', result.Errors.Select(e => e.Description).ToList());
            }
            return "Failed";
        }
    }
}
