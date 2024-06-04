using CoursesShop.Core.Features.Receipts.Commands.Requests;
using CoursesShop.Service.EntityServices.Interfaces;
using FluentValidation;

namespace CoursesShop.Core.Features.Receipts.Commands.Validators
{
    public sealed class AddReceiptValidator : AbstractValidator<AddReceiptRequest>
    {
        private readonly ICourseServices _courseServices;

        public AddReceiptValidator(ICourseServices courseServices)
        {
            ApplyCustomRule();
            _courseServices = courseServices;
        }

        private void ApplyCustomRule()
        {
            RuleFor(x => x.CourseId).NotNull().NotEmpty()
                                    .Must((key, cancellationToken) => _courseServices.IsIdExist(key.CourseId)).WithMessage("is not course id");
        }
    }
}
