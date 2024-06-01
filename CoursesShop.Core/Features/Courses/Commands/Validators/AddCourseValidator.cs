using CoursesShop.Core.Features.Courses.Commands.Requests;
using FluentValidation;

namespace CoursesShop.Core.Features.Courses.Commands.Validators
{
    public sealed class AddCourseValidator : AbstractValidator<AddCourseRequest>
    {
        public AddCourseValidator()
        {
            ApplyRule();
        }

        private void ApplyRule()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty().MinimumLength(2).MaximumLength(250);

            RuleFor(x => x.Price).NotNull().GreaterThan(0m).LessThan(1000.0m);

            RuleFor(x => x.Description).NotNull().NotEmpty().MinimumLength(10);
        }
    }
}
