using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Authentication.Commands.Requests;
using CoursesShop.Service.UserServices.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.Authentication.Commands.Handlers
{
    public sealed class SendResetPasswordCodeHandler(IUserServices userServices) : ResponseHandler, IRequestHandler<SendResetPasswordCodeRequest, Response<string>>
    {
        private readonly IUserServices _userServices = userServices;

        public async Task<Response<string>> Handle(SendResetPasswordCodeRequest request, CancellationToken cancellationToken)
        {
            var response = await _userServices.SendResetPasswordCode(request.UserName);
            if (response is "Success")
            {
                return Success(response);
            }
            else
            {
                return BadRequest<string>(response);
            }
        }
    }
}
