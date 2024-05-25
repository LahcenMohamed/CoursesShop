using Microsoft.AspNetCore.Identity;

namespace CoursesShop.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? TypeId { get; set; }
        public string? Code { get; set; }
        public List<UserRefreshToken>? UserRefreshTokens { get; set; }
    }
}
