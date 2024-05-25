using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Authentication.Commands.Requests;
using CoursesShop.Service.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.Authentication.Commands.Handlers
{
    public sealed class ResetPasswordHandler(IUserServices userServices) : ResponseHandler, IRequestHandler<ResetPasswordRequest, Response<string>>
    {
        private readonly IUserServices _userServices = userServices;

        public async Task<Response<string>> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
        {
            var response = await _userServices.ResetPassword(request.UserName, request.Password, request.Code);
            if (response == "Success")
            {
                return Success(response);
            }

            return BadRequest<string>();
        }
    }
}
