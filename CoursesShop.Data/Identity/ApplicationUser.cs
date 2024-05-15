using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CoursesShop.Data.Identity
{
    public sealed class ApplicationUser : IdentityUser
    {
        [AllowedValues("Admin", "Teacher", "Student")]
        public string Type { get; set; }
        public string? TypeId { get; set; }
        public List<UserRefreshToken>? UserRefreshTokens { get; set; }
    }
}
