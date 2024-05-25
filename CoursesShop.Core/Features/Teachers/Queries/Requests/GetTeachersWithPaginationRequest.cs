using CoursesShop.Core.Bases;
using CoursesShop.Core.Wrapper;
using CoursesShop.Data.Entities;
using MediatR;

namespace CoursesShop.Core.Features.Teachers.Queries.Requests
{
    public sealed class GetTeachersWithPaginationRequest : PaginatedResquestBase, IRequest<PaginatedResult<Teacher>>
    {
    }
}
