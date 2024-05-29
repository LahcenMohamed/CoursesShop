using CoursesShop.Core.Bases;
using MediatR;

namespace CoursesShop.Core.Features.Courses.Commands.Requests
{
    public sealed class DeleteCourseRequest : IRequest<Response<string>>
    {
        public required string Id { get; set; }
    }
}
