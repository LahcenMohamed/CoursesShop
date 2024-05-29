using AutoMapper;
using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Authorization.Command.Requests;
using CoursesShop.Service.UserServices.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CoursesShop.Core.Features.Authorization.Command.Handler
{
    public sealed class AddRoleHandler(IMapper mapper, IAuthorizationServices authorizationServices) : ResponseHandler, IRequestHandler<AddRoleRequest, Response<string>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IAuthorizationServices _authorizationServices = authorizationServices;

        public async Task<Response<string>> Handle(AddRoleRequest request, CancellationToken cancellationToken)
        {
            var role = _mapper.Map<IdentityRole>(request);
            var response = await _authorizationServices.Add(role);
            if (response.Contains("Error"))
            {
                return BadRequest<string>(response);
            }
            return Created<string>(response);
        }
    }
}
