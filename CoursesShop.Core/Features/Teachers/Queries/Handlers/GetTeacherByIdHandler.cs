using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Teachers.Queries.Requests;
using CoursesShop.Data.Entities;
using CoursesShop.Service.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.Teachers.Queries.Handlers
{
    public sealed class GetTeacherByIdHandler(ITeacherServices teacherServices) : ResponseHandler, IRequestHandler<GetTeacherByIdRequest, Response<Teacher>>
    {
        private readonly ITeacherServices _teacherServices = teacherServices;

        public async Task<Response<Teacher>> Handle(GetTeacherByIdRequest request, CancellationToken cancellationToken)
        {
            var response = _teacherServices.GetById(request.Id);
            return Success(response);
        }
    }
}
