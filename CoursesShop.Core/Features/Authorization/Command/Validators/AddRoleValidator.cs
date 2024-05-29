using CoursesShop.Core.Features.Authorization.Command.Requests;
using CoursesShop.Service.UserServices.Interfaces;
using FluentValidation;

namespace CoursesShop.Core.Features.Authorization.Command.Validators
{
    public sealed class AddRoleValidator : AbstractValidator<AddRoleRequest>
    {
        private readonly IAuthorizationServices _authorizationServices;

        public AddRoleValidator(IAuthorizationServices authorizationServices)
        {
            ApplyRules();
            ApplyCustomRules();
            _authorizationServices = authorizationServices;
        }

        private void ApplyCustomRules()
        {
            RuleFor(r => r.Name).Must((key, cancellationToken) => !_authorizationServices.isExistName(key.Name))
                                .WithMessage("is already exist");
        }

        private void ApplyRules()
        {
            RuleFor(x => x.Name).NotNull()
                                .NotEmpty()
                                .MaximumLength(50);
        }
    }
}
