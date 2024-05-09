using CoursesShop.Core.Bases;
using MediatR;

namespace CoursesShop.Core.Features.User.Commands.Requsets
{
    public sealed class AddUserRequest : IRequest<Response<string>>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
