using AutoMapper;
using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Reviews.Commands.Requests;
using CoursesShop.Data.Entities;
using CoursesShop.Service.EntityServices.Interfaces;
using CoursesShop.Service.UserServices.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.Reviews.Commands.Handlers
{
    public sealed class AddReviewHandler(ICurrentUserService currentUserService, IReviewServices reviewServices, IMapper mapper)
        : ResponseHandler, IRequestHandler<AddReviewRequest, Response<string>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IReviewServices _reviewServices = reviewServices;
        private readonly IMapper _mapper = mapper;

        public async Task<Response<string>> Handle(AddReviewRequest request, CancellationToken cancellationToken)
        {
            var studentId = _currentUserService.GetTypeId();

            var review = _mapper.Map<Review>(request);
            review.StudentId = studentId;

            await _reviewServices.AddAsync(review);
            return Created(review.Id);
        }
    }
}
