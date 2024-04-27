using CoursesShop.Core.Bases;
using MediatR;

namespace CoursesShop.Core.Features.Students.Commands.Models
{
    public sealed class DeleteStudentRequest : IRequest<Response<string>>
    {
        public string Id { get; set; }
    }
}
