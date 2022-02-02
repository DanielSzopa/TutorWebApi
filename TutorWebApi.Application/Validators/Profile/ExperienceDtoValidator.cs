using FluentValidation;
using TutorWebApi.Application.Models.Profile;

namespace TutorWebApi.Application.Validators.Profile
{
    public class ExperienceDtoValidator : AbstractValidator<ExperienceDto>
    {
        public ExperienceDtoValidator()
        {
            RuleFor(a => a.Description)
                .MaximumLength(150).WithMessage("Experience can not have more letters than 150")
                .NotEmpty().WithMessage("Experience can not be empty");
        }
    }
}
