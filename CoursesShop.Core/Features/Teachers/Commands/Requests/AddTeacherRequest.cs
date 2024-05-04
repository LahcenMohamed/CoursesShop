using CoursesShop.Core.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CoursesShop.Core.Features.Teachers.Commands.Requests
{
    public sealed class AddTeacherRequest : IRequest<Response<string>>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public IFormFile? image { get; set; }
    }
}
