using AutoMapper;
using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.User.Queries.Requsets;
using CoursesShop.Core.Features.User.Queries.Results;
using CoursesShop.Data.Identity;
using CoursesShop.Service.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.User.Queries.Handlers
{
    public sealed class GetAllUsersHandler(IUserServices userServices, IMapper mapper) : ResponseHandler, IRequestHandler<GetAllUsersRequest, Response<List<GetUserResult>>>
    {
        private readonly IUserServices _userServices = userServices;
        private readonly IMapper _mapper = mapper;

        public async Task<Response<List<GetUserResult>>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            List<ApplicationUser> lst = await _userServices.GetAll();
            var response = _mapper.Map<List<GetUserResult>>(lst);
            return Success(response);
        }
    }
}
