using CoursesShop.Core.Features.Courses.Commands.Requests;
using CoursesShop.Service.EntityServices.Interfaces;
using FluentValidation;

namespace CoursesShop.Core.Features.Courses.Commands.Validators
{
    public sealed class DeleteCourseValidator : AbstractValidator<DeleteCourseRequest>
    {
        private readonly ICourseServices _courseServices;

        public DeleteCourseValidator(ICourseServices courseServices)
        {
            ApplyCustomRule();
            _courseServices = courseServices;
        }

        private void ApplyCustomRule()
        {
            RuleFor(x => x.Id).Must((x, CancellationToken) => _courseServices.IsIdExist(x.Id)).WithMessage("Is not exist");
        }
    }
}
