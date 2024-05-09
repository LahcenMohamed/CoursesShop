using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoursesShop.Core.Features.User.Queries.Requsets;
using CoursesShop.Core.Features.User.Queries.Results;
using CoursesShop.Core.Wrapper;
using CoursesShop.Data.Identity;
using CoursesShop.Service.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.User.Queries.Handlers
{
    public sealed class GetUsersWithPaginationHandler(IUserServices userServices, IMapper mapper) : IRequestHandler<GetUsersWithPaginationRequest, PaginatedResult<GetUserResult>>
    {
        private readonly IUserServices _userServices = userServices;
        private readonly IMapper _mapper = mapper;

        public async Task<PaginatedResult<GetUserResult>> Handle(GetUsersWithPaginationRequest request, CancellationToken cancellationToken)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateProjection<ApplicationUser, GetUserResult>());
            IQueryable<GetUserResult> users;
            if (request.Search is null)
            {
                users = _userServices.GetAllAsQueryable().ProjectTo<GetUserResult>(config);
            }
            else
            {
                users = _userServices.UsersFilltering(request.Search).ProjectTo<GetUserResult>(config);
            }
            return await users.ToPaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
