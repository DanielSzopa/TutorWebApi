using FluentValidation;

namespace TutorWebApi.Application
{
    public class ExperienceDtoValidator : AbstractValidator<ExperienceDto>
    {
        public ExperienceDtoValidator()
        {
            RuleFor(a => a.Name)
                .MaximumLength(150).WithMessage("Experience can not have more letters than 150")
                .NotEmpty().WithMessage("Experience can not be empty");
        }
    }
}
