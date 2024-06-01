using CoursesShop.Core.Bases;
using MediatR;

namespace CoursesShop.Core.Features.Courses.Commands.Requests
{
    public sealed class DeleteCourseFromTeacherRequest : IRequest<Response<string>>
    {
        public required string CourseId { get; set; }
    }
}
