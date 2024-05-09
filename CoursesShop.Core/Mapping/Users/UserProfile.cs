using AutoMapper;

namespace CoursesShop.Core.Mapping.Users
{
    public partial class UserProfile : Profile
    {
        public UserProfile()
        {
            AddUserMapping();
            GetUserMapping();
        }
    }
}
