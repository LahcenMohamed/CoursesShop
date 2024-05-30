using CoursesShop.Core.Features.Reviews.Queries.Requests;
using CoursesShop.Service.EntityServices.Interfaces;
using FluentValidation;

namespace CoursesShop.Core.Features.Reviews.Queries.Validators
{
    public sealed class GetReviewsByCourseIdValidator : AbstractValidator<GetReviewsByCourseIdRequest>
    {
        private readonly ICourseServices _courseServices;

        public GetReviewsByCourseIdValidator(ICourseServices courseServices)
        {
            _courseServices = courseServices;
            ApplyCustomRule();
        }

        private void ApplyCustomRule()
        {
            RuleFor(x => x.CourseId).Must((x, cancellationToken) => _courseServices.IsIdExist(x.CourseId)).WithMessage("is not exist");
        }
    }
}
