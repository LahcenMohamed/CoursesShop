using CoursesShop.Core.Features.Students.Commands.Models;
using CoursesShop.Service.EntityServices.Interfaces;
using FluentValidation;

namespace CoursesShop.Core.Features.Students.Commands.Validators
{
    public sealed class AddStudentValidator : AbstractValidator<AddStudentRequest>
    {
        private readonly IStudentServices _studentServices;
        public AddStudentValidator(IStudentServices studentServices)
        {
            _studentServices = studentServices;
            ApplyValidationRule();
            CustomValidationRules();
        }

        public void ApplyValidationRule()
        {
            RuleFor(x => x.FullName).MinimumLength(5)
                                    .MaximumLength(100)
                                    .NotNull();

            RuleFor(x => x.Email).NotNull()
                                 .EmailAddress()
                                 .NotEmpty()
                                 .MaximumLength(100);
        }

        public void CustomValidationRules()
        {
            RuleFor(x => x.Email).MustAsync(async (Key, CancellationToken) => !await _studentServices.IsEmailExistAsync(Key))
                                 .WithMessage("Email is already exist");
        }
    }
}
