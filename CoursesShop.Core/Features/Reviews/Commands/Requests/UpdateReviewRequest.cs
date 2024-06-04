using CoursesShop.Core.Bases;
using MediatR;

namespace CoursesShop.Core.Features.Reviews.Commands.Requests
{
    public sealed class UpdateReviewRequest : IRequest<Response<string>>
    {
        public string Id { get; set; }
        public double Evalution { get; set; }
        public string? Comment { get; set; }
        public string CourseId { get; set; }
    }
}
