using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Authentication.Queries.Requests;
using CoursesShop.Service.UserServices.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.Authentication.Queries.Handlers
{
    public sealed class ConfirmEmailHandler(IUserServices userServices) : ResponseHandler, IRequestHandler<ConfirmEmailRequest, Response<string>>
    {
        private readonly IUserServices _userServices = userServices;

        public async Task<Response<string>> Handle(ConfirmEmailRequest request, CancellationToken cancellationToken)
        {
            var response = await _userServices.ConfirmEmail(request.userId, request.code);
            if (response is "Success")
            {
                return Success(response);
            }
            return BadRequest<string>(response);
        }
    }
}
