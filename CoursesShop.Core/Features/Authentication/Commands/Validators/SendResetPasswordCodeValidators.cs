using CoursesShop.Core.Features.Authentication.Commands.Requests;
using CoursesShop.Service.Interfaces;
using FluentValidation;

namespace CoursesShop.Core.Features.Authentication.Commands.Validators
{
    public sealed class SendResetPasswordCodeValidators : AbstractValidator<SendResetPasswordCodeRequest>
    {
        private readonly IUserServices _userServices;

        public SendResetPasswordCodeValidators(IUserServices userServices)
        {
            ApplyRule();
            ApplyCustomRule();
            _userServices = userServices;
        }

        private void ApplyCustomRule()
        {
            RuleFor(x => x.UserName).Must((key, CancellationToken) => _userServices.isUser(key.UserName));
        }

        private void ApplyRule()
        {
            RuleFor(x => x.UserName).NotNull()
                                    .NotEmpty();
        }
    }
}
