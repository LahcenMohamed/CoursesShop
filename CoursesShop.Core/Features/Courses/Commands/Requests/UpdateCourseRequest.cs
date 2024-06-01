using CoursesShop.Core.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CoursesShop.Core.Features.Courses.Commands.Requests
{
    public sealed class UpdateCourseRequest : IRequest<Response<string>>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
    }
}
