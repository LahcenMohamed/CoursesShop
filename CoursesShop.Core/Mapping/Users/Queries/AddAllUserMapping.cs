using CoursesShop.Core.Features.User.Queries.Results;
using CoursesShop.Data.Identity;

namespace CoursesShop.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void GetUserMapping()
        {
            CreateMap<ApplicationUser, GetUserResult>();

        }
    }
}
