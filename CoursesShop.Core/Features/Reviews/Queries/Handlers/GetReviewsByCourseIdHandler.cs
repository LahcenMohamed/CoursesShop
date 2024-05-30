using AutoMapper;
using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Reviews.Queries.Requests;
using CoursesShop.Core.Features.Reviews.Queries.Results;
using CoursesShop.Service.EntityServices.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.Reviews.Queries.Handlers
{
    public sealed class GetReviewsByCourseIdHandler(IReviewServices reviewServices, IMapper mapper) :
        ResponseHandler, IRequestHandler<GetReviewsByCourseIdRequest, Response<List<GetReviewResult>>>
    {
        private readonly IReviewServices _reviewServices = reviewServices;
        private readonly IMapper _mapper = mapper;

        public async Task<Response<List<GetReviewResult>>> Handle(GetReviewsByCourseIdRequest request, CancellationToken cancellationToken)
        {
            var reviews = await _reviewServices.GetAllByCourseIdAsync(request.CourseId);
            var reviewsMapping = _mapper.Map<List<GetReviewResult>>(reviews);
            return Success(reviewsMapping);
        }
    }
}
