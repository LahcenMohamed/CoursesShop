using CoursesShop.Core.Features.Authentication.Commands.Requests;
using CoursesShop.Service.Interfaces;
using FluentValidation;

namespace CoursesShop.Core.Features.Authentication.Commands.Validators
{
    public sealed class SignupValidator : AbstractValidator<SignupRequest>
    {
        private readonly IUserServices _userServices;

        public SignupValidator(IUserServices userServices)
        {
            ApplyRule();
            ApplyCustomRule();
            _userServices = userServices;
        }

        private void ApplyCustomRule()
        {
            RuleFor(x => x.UserName).Must((key, CancellationToken) => _userServices.isUser(key.UserName))
                                    .WithMessage("UserName is not correct");
        }

        private void ApplyRule()
        {
            RuleFor(x => x.UserName).NotEmpty()
                                    .NotNull()
                                    .MaximumLength(50)
                                    .MinimumLength(5);

            RuleFor(x => x.Password).NotEmpty()
                                    .NotNull()
                                    .MaximumLength(20)
                                    .MinimumLength(8);
        }
    }
}
