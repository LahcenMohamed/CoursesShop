using CoursesShop.Core.Features.Teachers.Commands.Requests;
using CoursesShop.Service.EntityServices.Interfaces;
using FluentValidation;

namespace CoursesShop.Core.Features.Teachers.Commands.Validators
{
    public sealed class DeleteTeacherValidator : AbstractValidator<DeleteTeacherRequest>
    {
        private readonly ITeacherServices _teacherServices;

        public DeleteTeacherValidator(ITeacherServices teacherServices)
        {
            _teacherServices = teacherServices;
            ApplyCustomRule();
        }

        private void ApplyCustomRule()
        {
            RuleFor(x => x.Id).NotEmpty()
                              .Must((key, CancellationToken) => _teacherServices.IsIdExist(key.Id))
                              .WithMessage("is not exist");
        }
    }
}
