using CoursesShop.Core.Features.Authentication.Queries.Requests;
using CoursesShop.Service.UserServices.Interfaces;
using FluentValidation;

namespace CoursesShop.Core.Features.Authentication.Queries.Validators
{
    public sealed class ConfirmEmailValidtor : AbstractValidator<ConfirmEmailRequest>
    {
        private readonly IUserServices _userServices;

        public ConfirmEmailValidtor(IUserServices userServices)
        {
            ApplyRule();
            ApplyCustomRule();
            _userServices = userServices;
        }

        private void ApplyCustomRule()
        {
            RuleFor(x => x.userId).Must((key, CancellationToken) => _userServices.isExistId(key.userId));
        }

        private void ApplyRule()
        {
            RuleFor(x => x.userId).NotNull()
                                  .NotEmpty();

            RuleFor(x => x.code).NotNull()
                                  .NotEmpty();
        }
    }
}
