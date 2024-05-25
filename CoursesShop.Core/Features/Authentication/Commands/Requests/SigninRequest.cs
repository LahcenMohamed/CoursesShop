using CoursesShop.Core.Bases;
using CoursesShop.Data.Results;
using MediatR;

namespace CoursesShop.Core.Features.Authentication.Commands.Requests
{
    public sealed class SigninRequest : IRequest<Response<JwtAuthResult>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
