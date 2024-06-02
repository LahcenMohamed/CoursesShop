using CoursesShop.Core.Features.Courses.Commands.Requests;
using CoursesShop.Service.EntityServices.Interfaces;
using CoursesShop.Service.UserServices.Interfaces;
using FluentValidation;

namespace CoursesShop.Core.Features.Courses.Commands.Validators
{
    public sealed class DeleteCourseFromTeacherValidator : AbstractValidator<DeleteCourseFromTeacherRequest>
    {
        private readonly ICourseServices _courseServices;
        private readonly ICurrentUserService _currentUserService;

        public DeleteCourseFromTeacherValidator(ICourseServices courseServices, ICurrentUserService currentUserService)
        {
            _courseServices = courseServices;
            _currentUserService = currentUserService;
            ApplyCustomRule();
        }

        private async void ApplyCustomRule()
        {
            var teacherId = _currentUserService.GetTypeId();
            RuleFor(x => x.CourseId).Must((key, cancellationToken) => _courseServices.IsCourseIdToTeacherId(key.CourseId, teacherId)).WithMessage("is not Who created it");
        }
    }
}
