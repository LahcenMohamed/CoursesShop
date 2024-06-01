using CoursesShop.Core.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CoursesShop.Core.Features.Courses.Commands.Requests
{
    public sealed class AddCourseRequest : IRequest<Response<string>>
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
    }
}
