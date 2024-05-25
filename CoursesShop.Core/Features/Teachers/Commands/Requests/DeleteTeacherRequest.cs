using CoursesShop.Core.Bases;
using MediatR;

namespace CoursesShop.Core.Features.Teachers.Commands.Requests
{
    public sealed class DeleteTeacherRequest : IRequest<Response<string>>
    {
        public required string Id { get; set; }
    }
}
