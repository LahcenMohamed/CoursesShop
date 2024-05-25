using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Teachers.Queries.Requests;
using CoursesShop.Data.Entities;
using CoursesShop.Service.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.Teachers.Queries.Handlers
{
    public sealed class GetAllTeachersHandler(ITeacherServices teacherServices) : ResponseHandler, IRequestHandler<GetAllTeachersRequest, Response<List<Teacher>>>
    {
        private readonly ITeacherServices _teacherServices = teacherServices;

        public async Task<Response<List<Teacher>>> Handle(GetAllTeachersRequest request, CancellationToken cancellationToken)
        {
            var response = await _teacherServices.GetAllAsync();
            return Success(response);
        }
    }
}
