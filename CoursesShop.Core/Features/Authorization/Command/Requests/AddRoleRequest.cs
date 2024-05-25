using CoursesShop.Core.Bases;
using MediatR;

namespace CoursesShop.Core.Features.Authorization.Command.Requests
{
    public sealed class AddRoleRequest : IRequest<Response<string>>
    {
        public string Name { get; set; }
    }
}
