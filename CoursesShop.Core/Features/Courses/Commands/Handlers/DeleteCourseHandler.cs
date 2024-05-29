using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Courses.Commands.Requests;
using CoursesShop.Service.EntityServices.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.Courses.Commands.Handlers
{
    public sealed class DeleteCourseHandler(ICourseServices courseServices) : ResponseHandler, IRequestHandler<DeleteCourseRequest, Response<string>>
    {
        private readonly ICourseServices _courseServices = courseServices;

        public async Task<Response<string>> Handle(DeleteCourseRequest request, CancellationToken cancellationToken)
        {
            await _courseServices.DeleteAsync(request.Id);
            return Deleted<string>();
        }
    }
}
