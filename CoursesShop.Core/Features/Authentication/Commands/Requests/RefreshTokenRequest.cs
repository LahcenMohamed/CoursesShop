using CoursesShop.Core.Bases;
using CoursesShop.Data.Results;
using MediatR;

namespace CoursesShop.Core.Features.Authentication.Commands.Requests
{
    public sealed class RefreshTokenRequest : IRequest<Response<JwtAuthResult>>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
