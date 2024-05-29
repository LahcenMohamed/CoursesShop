using CoursesShop.Core.Features.User.Commands.Requsets;
using CoursesShop.Service.UserServices.Interfaces;
using FluentValidation;

namespace CoursesShop.Core.Features.User.Commands.Validators
{
    public sealed class DeleteUserValidator : AbstractValidator<DeleteUserRequest>
    {
        private readonly IUserServices _userServices;

        public DeleteUserValidator(IUserServices userServices)
        {
            ApplyCustomRule();
            _userServices = userServices;
        }

        private void ApplyCustomRule()
        {
            RuleFor(x => x.Id).Must((key, CancellationToken) => _userServices.isExistId(key.Id))
                              .WithMessage("did not find user with this Id");

        }
    }
}
