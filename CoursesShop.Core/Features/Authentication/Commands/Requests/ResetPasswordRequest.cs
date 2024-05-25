using CoursesShop.Core.Bases;
using MediatR;

namespace CoursesShop.Core.Features.Authentication.Commands.Requests
{
    public sealed class ResetPasswordRequest : IRequest<Response<string>>
    {
        public string Code { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
