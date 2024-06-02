using CoursesShop.Core.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CoursesShop.Core.Features.Teachers.Commands.Requests
{
    public sealed class UpdateTeacherImageRequest : IRequest<Response<string>>
    {
        public IFormFile Image { get; set; }
    }
}
