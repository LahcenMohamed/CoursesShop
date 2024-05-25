using CoursesShop.Core.Bases;
using MediatR;

namespace CoursesShop.Core.Features.Authentication.Commands.Requests
{
    public sealed class SendResetPasswordCodeRequest : IRequest<Response<string>>
    {
        public string UserName { get; set; }
    }
}
