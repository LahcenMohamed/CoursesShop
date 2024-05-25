using CoursesShop.Core.Features.Authorization.Command.Requests;
using Microsoft.AspNetCore.Identity;

namespace CoursesShop.Core.Mapping.Roles
{
    public partial class RoleProfile
    {
        public void AddRoleMapping()
        {
            CreateMap<AddRoleRequest, IdentityRole>();
        }
    }
}
