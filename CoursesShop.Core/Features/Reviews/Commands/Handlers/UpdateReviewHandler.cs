using AutoMapper;
using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Reviews.Commands.Requests;
using CoursesShop.Data.Entities;
using CoursesShop.Service.EntityServices.Interfaces;
using CoursesShop.Service.UserServices.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.Reviews.Commands.Handlers
{
    public sealed class UpdateReviewHandler(ICurrentUserService currentUserService, IReviewServices reviewServices, IMapper mapper)
        : ResponseHandler, IRequestHandler<UpdateReviewRequest, Response<string>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IReviewServices _reviewServices = reviewServices;
        private readonly IMapper _mapper = mapper;

        public async Task<Response<string>> Handle(UpdateReviewRequest request, CancellationToken cancellationToken)
        {
            var studentId = _currentUserService.GetTypeId();

            var review = _mapper.Map<Review>(request);
            review.StudentId = studentId;

            await _reviewServices.UpdateAsync(review);
            return Success(review.Id);
        }
    }
}
