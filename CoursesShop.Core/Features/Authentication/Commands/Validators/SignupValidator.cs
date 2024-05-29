using CoursesShop.Core.Features.Authentication.Commands.Requests;
using CoursesShop.Service.UserServices.Interfaces;
using FluentValidation;

namespace CoursesShop.Core.Features.Authentication.Commands.Validators
{
    public sealed class SignupValidator : AbstractValidator<SignupRequest>
    {
        private readonly IUserServices _userServices;

        public SignupValidator(IUserServices userServices)
        {
            ApplyValidationRule();
            ApplyCustomValidationRule();
            _userServices = userServices;
        }

        private void ApplyValidationRule()
        {
            RuleFor(x => x.UserName).NotEmpty()
                                    .NotNull()
                                    .MaximumLength(50)
                                    .MinimumLength(5);

            RuleFor(x => x.Email).NotNull()
                                 .NotEmpty()
                                 .EmailAddress();

            RuleFor(x => x.Password).NotEmpty()
                                    .NotNull()
                                    .MaximumLength(20)
                                    .MinimumLength(8);

            RuleFor(x => x.Type).NotNull()
                                .NotEmpty()
                                .Must(key => key == "Teacher" || key == "Student");
        }

        private void ApplyCustomValidationRule()
        {
            RuleFor(x => x.UserName).Must((key, CancellationToken) => !_userServices.isUser(key.UserName))
                                 .WithMessage("is already used");

            RuleFor(x => x.Email).Must((Key, CancellationToken) => !_userServices.isExistEmail(Key.Email))
                                 .WithMessage("is already used");
        }
    }
}
