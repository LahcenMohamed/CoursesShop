using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Courses.Queries.Results;
using MediatR;

namespace CoursesShop.Core.Features.Courses.Queries.Requests
{
    public sealed class GetCoursesByTeacherIdRequest : IRequest<Response<List<GetCourseResult>>>
    {
    }
}
