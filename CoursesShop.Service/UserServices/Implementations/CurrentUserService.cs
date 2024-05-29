using CoursesShop.Data.Identity;
using CoursesShop.Service.UserServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CoursesShop.Service.UserServices.Implementations
{
    public sealed class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public int GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == nameof(ClaimTypes.NameIdentifier)).Value;
            if (userId == null)
            {
                throw new UnauthorizedAccessException();
            }
            return int.Parse(userId);
        }

        public async Task<ApplicationUser> GetUserAsync()
        {
            var userId = GetUserId();
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            { throw new UnauthorizedAccessException(); }
            return user;
        }

        public async Task<List<string>> GetCurrentUserRolesAsync()
        {
            var user = await GetUserAsync();
            var roles = await _userManager.GetRolesAsync(user);
            return roles.ToList();
        }
    }
}
