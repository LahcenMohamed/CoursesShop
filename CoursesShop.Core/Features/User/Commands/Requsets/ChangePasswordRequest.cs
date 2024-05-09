using CoursesShop.Core.Bases;
using MediatR;

namespace CoursesShop.Core.Features.User.Commands.Requsets
{
    public sealed class ChangePasswordRequest : IRequest<Response<string>>
    {
        public string Id { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
