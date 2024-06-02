using CoursesShop.Core.Features.Courses.Commands.Requests;
using CoursesShop.Service.EntityServices.Interfaces;
using CoursesShop.Service.UserServices.Interfaces;
using FluentValidation;

namespace CoursesShop.Core.Features.Courses.Commands.Validators
{
    public sealed class UpdateCourseValidator : AbstractValidator<UpdateCourseRequest>
    {
        private readonly ICourseServices _courseServices;
        private readonly ICurrentUserService _currentUserService;
        public UpdateCourseValidator(ICourseServices courseServices, ICurrentUserService currentUserService)
        {
            _courseServices = courseServices;
            _currentUserService = currentUserService;
            ApplyRule();
            ApplycCustomRule();
        }

        private void ApplycCustomRule()
        {
            string teacherId = _currentUserService.GetTypeId();
            RuleFor(x => x.Id).Must((key, cancellationToken) => _courseServices.IsCourseIdToTeacherId(key.Id, teacherId)).WithMessage("is not Who created it");
        }

        private void ApplyRule()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty().MinimumLength(2).MaximumLength(250);

            RuleFor(x => x.Price).NotNull().GreaterThan(0m).LessThan(1000.0m);

            RuleFor(x => x.Description).NotNull().NotEmpty().MinimumLength(10);
        }
    }
}
