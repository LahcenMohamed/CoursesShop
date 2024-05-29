using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Students.Commands.Models;
using CoursesShop.Service.EntityServices.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.Students.Commands.Handlers
{
    public sealed class DeleteStudentHandler(IStudentServices studentServices) : ResponseHandler, IRequestHandler<DeleteStudentRequest, Response<string>>
    {
        private readonly IStudentServices _studentServices = studentServices;
        public async Task<Response<string>> Handle(DeleteStudentRequest request, CancellationToken cancellationToken)
        {
            await _studentServices.DeleteAsync(request.Id);
            return Deleted<string>();
        }
    }
}
