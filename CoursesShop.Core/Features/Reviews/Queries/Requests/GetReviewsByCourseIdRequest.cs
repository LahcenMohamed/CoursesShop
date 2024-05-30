using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Reviews.Queries.Results;
using MediatR;

namespace CoursesShop.Core.Features.Reviews.Queries.Requests
{
    public sealed class GetReviewsByCourseIdRequest : IRequest<Response<List<GetReviewResult>>>
    {
        public required string CourseId { get; set; }
    }
}
