using CoursesShop.Core.Bases;
using MediatR;

namespace CoursesShop.Core.Features.User.Commands.Requsets
{
    public sealed class DeleteUserRequest : IRequest<Response<string>>
    {
        public required string Id { get; set; }
    }
}
