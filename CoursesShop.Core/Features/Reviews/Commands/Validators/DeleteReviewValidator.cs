using CoursesShop.Core.Features.Reviews.Commands.Requests;
using CoursesShop.Service.EntityServices.Interfaces;
using FluentValidation;

namespace CoursesShop.Core.Features.Reviews.Commands.Validators
{
    public sealed class DeleteReviewValidator : AbstractValidator<DeleteReviewRequest>
    {
        private readonly IReviewServices _reviewServices;

        public DeleteReviewValidator(IReviewServices reviewServices)
        {
            _reviewServices = reviewServices;
            ApplyCustomRule();
        }

        private void ApplyCustomRule()
        {
            RuleFor(x => x.Id).Must((x, cancellationToken) => _reviewServices.IsIdExist(x.Id)).WithMessage("Is not exist");
        }
    }
}
