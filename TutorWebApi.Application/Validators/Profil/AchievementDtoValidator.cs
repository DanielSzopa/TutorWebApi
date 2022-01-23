using FluentValidation;

namespace TutorWebApi.Application
{
    public class AchievementDtoValidator : AbstractValidator<AchievementDto>
    {
        public AchievementDtoValidator()
        {
            RuleFor(a => a.Name)
                .MaximumLength(150).WithMessage("Achievement can not have more letters than 150")
                .NotEmpty().WithMessage("Achievement can not be empty");
        }
    }
}
