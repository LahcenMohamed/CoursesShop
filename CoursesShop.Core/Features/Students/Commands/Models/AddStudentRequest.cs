using CoursesShop.Core.Bases;
using MediatR;

namespace CoursesShop.Core.Features.Students.Commands.Models
{
    public sealed class AddStudentRequest : IRequest<Response<string>>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
