using CoursesShop.Core.Features.Reviews.Commands.Requests;
using CoursesShop.Service.EntityServices.Interfaces;
using CoursesShop.Service.UserServices.Interfaces;
using FluentValidation;

namespace CoursesShop.Core.Features.Reviews.Commands.Validators
{
    public sealed class DeleteReviewByStudentValidator : AbstractValidator<DeleteReviewByStudentRequest>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IReviewServices _reviewServices;

        public DeleteReviewByStudentValidator(ICurrentUserService currentUserService,
                                     IReviewServices reviewServices)
        {
            _currentUserService = currentUserService;
            _reviewServices = reviewServices;
            ApplyCustomRule();
        }

        private void ApplyCustomRule()
        {
            var studentId = _currentUserService.GetTypeId();

            RuleFor(x => x.Id).Must((key, cancellationToken) => _reviewServices.IsReviewFromStudent(key.Id, studentId));
        }
    }
}
