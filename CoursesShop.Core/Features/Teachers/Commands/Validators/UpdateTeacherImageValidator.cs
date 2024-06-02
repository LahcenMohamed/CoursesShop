using CoursesShop.Core.Features.Teachers.Commands.Requests;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace CoursesShop.Core.Features.Teachers.Commands.Validators
{
    public sealed class UpdateTeacherImageValidator : AbstractValidator<UpdateTeacherImageRequest>
    {
        public UpdateTeacherImageValidator()
        {
            ApplyRule();
        }

        private void ApplyRule()
        {
            RuleFor(x => x.Image).NotNull().NotEmpty()
                                 .Must(BeAValidPhoto).WithMessage("Invalid photo file. Only JPEG, PNG, and GIF formats are allowed."); ;
        }

        private bool BeAValidPhoto(IFormFile file)
        {
            if (file == null)
                return false;

            var allowedContentTypes = new[] { "image/jpeg", "image/png", "image/gif" };
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };

            var isValidContentType = allowedContentTypes.Contains(file.ContentType);
            var isValidExtension = allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower());

            return isValidContentType && isValidExtension;
        }
    }
}
