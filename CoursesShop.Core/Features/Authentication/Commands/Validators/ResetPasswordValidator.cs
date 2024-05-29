using CoursesShop.Core.Features.Authentication.Commands.Requests;
using CoursesShop.Service.UserServices.Interfaces;
using FluentValidation;

namespace CoursesShop.Core.Features.Authentication.Commands.Validators
{
    public sealed class ResetPasswordValidator : AbstractValidator<ResetPasswordRequest>
    {
        private readonly IUserServices _userServices;

        public ResetPasswordValidator(IUserServices userServices)
        {
            ApplyRule();
            _userServices = userServices;
        }

        private void ApplyRule()
        {
            RuleFor(x => x.Code).NotEmpty()
                                .NotNull()
                                .Length(6);

            RuleFor(x => x.UserName).NotEmpty()
                                    .NotNull();

            RuleFor(x => x.Password).NotEmpty()
                                    .NotNull();
        }

        private void ApplyCustomRule()
        {
            RuleFor(x => x.UserName).Must((key, CancellationToken) => _userServices.isUser(key.UserName));
        }
    }
}
