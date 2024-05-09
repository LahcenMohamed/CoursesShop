using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.User.Queries.Results;
using CoursesShop.Core.Wrapper;
using MediatR;

namespace CoursesShop.Core.Features.User.Queries.Requsets
{
    public sealed class GetUsersWithPaginationRequest : PaginatedResquestBase, IRequest<PaginatedResult<GetUserResult>>
    {
    }
}
