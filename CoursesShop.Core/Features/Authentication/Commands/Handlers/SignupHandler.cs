using AutoMapper;
using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Authentication.Commands.Requests;
using CoursesShop.Data.Identity;
using CoursesShop.Service.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.Authentication.Commands.Handlers
{
    public sealed class SignupHandler(IUserServices userServices, IMapper mapper) : ResponseHandler, IRequestHandler<SignupRequest, Response<string>>
    {
        private readonly IUserServices _userServices = userServices;
        private readonly IMapper _mapper = mapper;

        public async Task<Response<string>> Handle(SignupRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<ApplicationUser>(request);
            var response = await _userServices.Add(user, request.Password, request.Type);
            if (response.Contains("Error"))
            {
                return BadRequest<string>(response);
            }
            return Created(response);
        }
    }
}
