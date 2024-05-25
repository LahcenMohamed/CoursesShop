using CoursesShop.Core.Bases;
using MediatR;

namespace CoursesShop.Core.Features.Authentication.Commands.Requests
{
    public sealed class SignupRequest : IRequest<Response<string>>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public string TypeId { get; set; }
    }
}
