using CoursesShop.Core.Features.Reviews.Commands.Requests;
using CoursesShop.Service.EntityServices.Interfaces;
using CoursesShop.Service.UserServices.Interfaces;
using FluentValidation;

namespace CoursesShop.Core.Features.Reviews.Commands.Validators
{
    public sealed class AddReviewValidator : AbstractValidator<AddReviewRequest>
    {
        private readonly IReceiptServices _receiptServices;
        private readonly ICurrentUserService _currentUserService;
        private readonly IReviewServices _reviewServices;

        public AddReviewValidator(IReceiptServices receiptServices,
                                  ICurrentUserService currentUserService,
                                  IReviewServices reviewServices)
        {
            _receiptServices = receiptServices;
            _currentUserService = currentUserService;
            _reviewServices = reviewServices;
            ApplyRule();
            ApplyCustomRule();
        }

        private void ApplyCustomRule()
        {
            var studentId = _currentUserService.GetTypeId();
            RuleFor(x => x.CourseId).Must((key, cancellationToken) => _receiptServices.IsStudentByThisCourse(key.CourseId, studentId))
                                    .WithMessage("student must buy this course to review it")
                                    .Must((key, cancellationToken) => !_reviewServices.IsStudentReview(studentId))
                                    .WithMessage("student can just add one review");
        }

        private void ApplyRule()
        {
            RuleFor(x => x.Evalution).NotNull().NotEmpty().LessThan(5.0).GreaterThan(0.0);

            RuleFor(x => x.CourseId).NotNull().NotEmpty();
        }
    }
}
