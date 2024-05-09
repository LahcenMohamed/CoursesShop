using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.User.Queries.Results;
using MediatR;

namespace CoursesShop.Core.Features.User.Queries.Requsets
{
    public sealed class GetAllUsersRequest : IRequest<Response<List<GetUserResult>>>
    {
    }
}
