using CoursesShop.Core.Bases;
using MediatR;

namespace CoursesShop.Core.Features.Reviews.Commands.Requests
{
    public sealed class DeleteReviewRequest : IRequest<Response<string>>
    {
        public required string Id { get; set; }
    }
}
