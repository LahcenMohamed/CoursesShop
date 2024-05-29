using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Courses.Queries.Results;
using CoursesShop.Core.Wrapper;
using MediatR;

namespace CoursesShop.Core.Features.Courses.Queries.Requests
{
    public sealed class GetCoursesWithPaginationRequest : PaginatedResquestBase, IRequest<PaginatedResult<GetCourseResult>>
    {
    }
}
