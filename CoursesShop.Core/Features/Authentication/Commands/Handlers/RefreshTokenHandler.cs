using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Authentication.Commands.Requests;
using CoursesShop.Data.Results;
using CoursesShop.Service.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.Authentication.Commands.Handlers
{
    public sealed class RefreshTokenHandler(IAuthenticationServices authenticationServices,
                                            IUserServices userServices) : ResponseHandler, IRequestHandler<RefreshTokenRequest, Response<JwtAuthResult>>
    {
        private readonly IAuthenticationServices _authenticationServices = authenticationServices;
        private readonly IUserServices _userServices = userServices;

        public async Task<Response<JwtAuthResult>> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var jwtToken = _authenticationServices.ReadJWTToken(request.AccessToken);
            var (userId, ExpireDate) = await _authenticationServices.ValidateDetails(jwtToken, request.AccessToken, request.RefreshToken);
            if (ExpireDate is null)
            {
                return Unauthorized<JwtAuthResult>(userId);
            }
            var user = await _userServices.GetById(userId);
            if (user == null)
            {
                return NotFound<JwtAuthResult>();
            }
            var result = await _authenticationServices.GetRefreshTokenAsync(user, jwtToken, ExpireDate, request.RefreshToken);
            return Success(result);
        }
    }
}
