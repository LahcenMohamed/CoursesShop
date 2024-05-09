using CoursesShop.Core.Features.User.Commands.Requsets;
using CoursesShop.Data.Identity;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace CoursesShop.Core.Features.User.Commands.Validators
{
    public sealed class AddUserValidator : AbstractValidator<AddUserRequest>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AddUserValidator(UserManager<ApplicationUser> userManager)
        {
            ApplyValidationRule();
            ApplyCustomValidationRule();
            _userManager = userManager;
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
        }

        private void ApplyCustomValidationRule()
        {
            RuleFor(x => x.UserName).MustAsync(async (Key, CancellationToken) => await _userManager.FindByNameAsync(Key) is null)
                                 .WithMessage("is already used");

            RuleFor(x => x.Email).MustAsync(async (Key, CancellationToken) => await _userManager.FindByEmailAsync(Key) is null)
                                 .WithMessage("is already used");
        }


    }
}
