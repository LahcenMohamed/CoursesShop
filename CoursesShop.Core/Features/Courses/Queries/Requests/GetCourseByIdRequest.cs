using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Courses.Queries.Results;
using MediatR;

namespace CoursesShop.Core.Features.Courses.Queries.Requests
{
    public sealed class GetCourseByIdRequest : IRequest<Response<GetCourseResult>>
    {
        public required string Id { get; set; }
    }
}
