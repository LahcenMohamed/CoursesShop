using CoursesShop.Core.Features.Reviews.Commands.Requests;
using CoursesShop.Service.EntityServices.Interfaces;
using CoursesShop.Service.UserServices.Interfaces;
using FluentValidation;

namespace CoursesShop.Core.Features.Reviews.Commands.Validators
{
    public sealed class UpdateReviewValidator : AbstractValidator<UpdateReviewRequest>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IReviewServices _reviewServices;

        public UpdateReviewValidator(ICurrentUserService currentUserService,
                                     IReviewServices reviewServices)
        {
            _currentUserService = currentUserService;
            _reviewServices = reviewServices;
            ApplyRule();
            ApplyCustomRule();
        }

        private void ApplyCustomRule()
        {
            var studentId = _currentUserService.GetTypeId();

            RuleFor(x => x.Id).Must((key, cancellationToken) => _reviewServices.IsReviewFromStudent(key.Id, studentId));
        }

        private void ApplyRule()
        {
            RuleFor(x => x.Evalution).NotNull().NotEmpty().LessThan(5.0).GreaterThan(0.0);

            RuleFor(x => x.CourseId).NotNull().NotEmpty();

            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}
