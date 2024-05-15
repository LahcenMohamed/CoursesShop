using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Authentication.Commands.Requests;
using CoursesShop.Data.Results;
using CoursesShop.Service.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.Authentication.Commands.Handlers
{
    public sealed class SignupHandler(IAuthenticationServices authenticationServices) : ResponseHandler, IRequestHandler<SignupRequest, Response<JwtAuthResult>>
    {
        private readonly IAuthenticationServices _authenticationServices = authenticationServices;

        public async Task<Response<JwtAuthResult>> Handle(SignupRequest request, CancellationToken cancellationToken)
        {
            var token = await _authenticationServices.SignupAsync(request.UserName, request.Password);
            if (token is null)
            {
                return Unauthorized<JwtAuthResult>();
            }
            return Success(token);
        }
    }
}
