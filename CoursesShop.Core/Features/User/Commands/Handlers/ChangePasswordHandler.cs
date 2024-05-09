using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.User.Commands.Requsets;
using CoursesShop.Service.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.User.Commands.Handlers
{
    public sealed class ChangePasswordHandler(IUserServices userServices) : ResponseHandler, IRequestHandler<ChangePasswordRequest, Response<string>>
    {
        private readonly IUserServices _userServices = userServices;

        public async Task<Response<string>> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            var response = await _userServices.ChangePassword(request.Id, request.CurrentPassword, request.NewPassword);
            if (response is "Succeeded")
            {
                return Success<string>(response);
            }
            return BadRequest<string>(response);
        }
    }
}
