using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Teachers.Commands.Requests;
using CoursesShop.Service.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.Teachers.Commands.Handlers
{
    public sealed class DeleteTeacherHandler(ITeacherServices teacherServices) : ResponseHandler, IRequestHandler<DeleteTeacherRequest, Response<string>>
    {
        private readonly ITeacherServices _teacherServices = teacherServices;

        public async Task<Response<string>> Handle(DeleteTeacherRequest request, CancellationToken cancellationToken)
        {
            await _teacherServices.DeleteAsync(request.Id);
            return Deleted<string>();
        }
    }
}
