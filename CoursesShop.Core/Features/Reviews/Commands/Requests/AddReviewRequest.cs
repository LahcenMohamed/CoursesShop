using CoursesShop.Core.Bases;
using MediatR;

namespace CoursesShop.Core.Features.Reviews.Commands.Requests
{
    public sealed class AddReviewRequest : IRequest<Response<string>>
    {
        public double Evalution { get; set; }
        public string? Comment { get; set; }
        public string CourseId { get; set; }
    }
}
