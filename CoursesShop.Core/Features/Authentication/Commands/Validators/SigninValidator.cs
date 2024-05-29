using CoursesShop.Core.Features.Authentication.Commands.Requests;
using CoursesShop.Service.UserServices.Interfaces;
using FluentValidation;

namespace CoursesShop.Core.Features.Authentication.Commands.Validators
{
    public sealed class SigninValidator : AbstractValidator<SigninRequest>
    {
        private readonly IUserServices _userServices;

        public SigninValidator(IUserServices userServices)
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
                                    .MinimumLength(4);

            RuleFor(x => x.Password).NotEmpty()
                                    .NotNull()
                                    .MaximumLength(20)
                                    .MinimumLength(8);
        }
    }
}
