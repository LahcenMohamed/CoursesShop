using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Teachers.Commands.Requests;
using CoursesShop.Service.EntityServices.Interfaces;
using CoursesShop.Service.UserServices.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.Teachers.Commands.Handlers
{
    public sealed class UpdateTeacherImageHandler(ICurrentUserService currentUserService, ITeacherServices teacherServices)
        : ResponseHandler, IRequestHandler<UpdateTeacherImageRequest, Response<string>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly ITeacherServices _teacherServices = teacherServices;

        public async Task<Response<string>> Handle(UpdateTeacherImageRequest request, CancellationToken cancellationToken)
        {
            var teacherId = _currentUserService.GetTypeId();
            await _teacherServices.UpdateImageAsync(teacherId, request.Image);
            return Success(teacherId);
        }
    }
}
