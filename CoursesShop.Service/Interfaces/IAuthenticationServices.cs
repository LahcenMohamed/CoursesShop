using CoursesShop.Data.Identity;
using CoursesShop.Data.Results;
using System.IdentityModel.Tokens.Jwt;

namespace CoursesShop.Service.Interfaces
{
    public interface IAuthenticationServices
    {
        public Task<JwtAuthResult> SignupAsync(string userName, string password);
        public Task<JwtAuthResult> GetRefreshTokenAsync(ApplicationUser user, JwtSecurityToken jwtToken, DateTime? expiryDate, string refreshToken);
        public Task<string> ValidateToken(string accessToken);
        public Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken jwtToken, string accessToken, string refreshToken);
        public JwtSecurityToken ReadJWTToken(string accessToken);

    }
}
