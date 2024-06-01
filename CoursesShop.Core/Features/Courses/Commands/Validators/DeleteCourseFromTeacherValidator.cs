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
        private object locker = new object();

        public DeleteCourseFromTeacherValidator(ICourseServices courseServices, ICurrentUserService currentUserService)
        {
            _courseServices = courseServices;
            _currentUserService = currentUserService;
            ApplyCustomRule();
        }

        private async void ApplyCustomRule()
        {
            lock (locker)
            {
                var user = _currentUserService.GetUserAsync();

                RuleFor(x => x.CourseId).Must((key, cancellationToken) => _courseServices.IsCourseIdToTeacherId(key.CourseId, user.Result.TypeId)).WithMessage("is not Who created it");
            }

        }
    }
}
