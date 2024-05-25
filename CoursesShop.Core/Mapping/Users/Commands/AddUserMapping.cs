using CoursesShop.Core.Features.Authentication.Commands.Requests;
using CoursesShop.Core.Features.User.Commands.Requsets;
using CoursesShop.Data.Identity;

namespace CoursesShop.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void AddUserMapping()
        {
            CreateMap<AddUserRequest, ApplicationUser>();
            CreateMap<SignupRequest, ApplicationUser>();
        }
    }
}
