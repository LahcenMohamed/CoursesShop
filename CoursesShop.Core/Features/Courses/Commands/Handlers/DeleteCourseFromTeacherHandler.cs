using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Courses.Commands.Requests;
using CoursesShop.Service.EntityServices.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.Courses.Commands.Handlers
{
    public sealed class DeleteCourseFromTeacherHandler(ICourseServices courseServices)
        : ResponseHandler, IRequestHandler<DeleteCourseFromTeacherRequest, Response<string>>
    {
        private readonly ICourseServices _courseServices = courseServices;

        public async Task<Response<string>> Handle(DeleteCourseFromTeacherRequest request, CancellationToken cancellationToken)
        {
            await _courseServices.DeleteAsync(request.CourseId);

            return Deleted<string>();
        }
    }
}
