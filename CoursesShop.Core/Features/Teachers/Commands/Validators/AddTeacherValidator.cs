using CoursesShop.Core.Features.Teachers.Commands.Requests;
using CoursesShop.Service.Interfaces;
using FluentValidation;

namespace CoursesShop.Core.Features.Teachers.Commands.Validators
{
    public sealed class AddTeacherValidator : AbstractValidator<AddTeacherRequest>
    {
        private readonly ITeacherServices _teacherServices;
        public AddTeacherValidator(ITeacherServices teacherServices)
        {
            _teacherServices = teacherServices;
            ApplyValidationRule();
            ApplyCustomValidationRule();
        }

        public void ApplyValidationRule()
        {
            RuleFor(x => x.FullName).NotNull()
                                    .MinimumLength(5)
                                    .MaximumLength(100);

            RuleFor(x => x.Email).NotNull()
                                 .MinimumLength(5)
                                 .EmailAddress();
        }

        public void ApplyCustomValidationRule()
        {
            RuleFor(x => x.Email).MustAsync(async (Key, CancellationToken) => !await _teacherServices.IsEmailExistAsync(Key))
                                 .WithMessage("this email is already used");
        }
    }
}
