using CoursesShop.Core.Features.Courses.Queries.Requests;
using CoursesShop.Service.EntityServices.Interfaces;
using FluentValidation;

namespace CoursesShop.Core.Features.Courses.Queries.Validators
{
    public sealed class GetCourseByIdValidator : AbstractValidator<GetCourseByIdRequest>
    {
        private readonly ICourseServices _courseServices;

        public GetCourseByIdValidator(ICourseServices courseServices)
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
