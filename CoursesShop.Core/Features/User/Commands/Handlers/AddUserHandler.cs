using AutoMapper;
using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.User.Commands.Requsets;
using CoursesShop.Data.Identity;
using CoursesShop.Service.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.User.Commands.Handlers
{
    public sealed class AddUserHandler(IUserServices userServices, IMapper mapper) : ResponseHandler, IRequestHandler<AddUserRequest, Response<string>>
    {
        private readonly IUserServices _userServices = userServices;
        private readonly IMapper _mapper = mapper;

        public async Task<Response<string>> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<ApplicationUser>(request);
            var response = await _userServices.Add(user, request.Password);
            if (response.Contains("Error"))
            {
                return BadRequest<string>(response);
            }
            return Created<string>(response);

        }
    }
}
