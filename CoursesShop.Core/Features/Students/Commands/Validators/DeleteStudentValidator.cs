using CoursesShop.Core.Features.Students.Commands.Models;
using CoursesShop.Service.Abstracts;
using FluentValidation;

namespace CoursesShop.Core.Features.Students.Commands.Validators
{
    public sealed class DeleteStudentValidator : AbstractValidator<DeleteStudentRequest>
    {
        private readonly IStudentServices _studentServices;
        public DeleteStudentValidator(IStudentServices studentServices)
        {
            _studentServices = studentServices;
            ApplyValidationRule();
            CustomValidationRules();
        }

        public void ApplyValidationRule()
        {
            RuleFor(x => x.Id).NotNull()
                              .NotEmpty();
        }

        public void CustomValidationRules()
        {
            RuleFor(x => x.Id).MustAsync(async (Key, CancellationToken) => await _studentServices.IsIdExistAsync(Key))
                              .WithMessage("not found Id");
        }
    }
}
