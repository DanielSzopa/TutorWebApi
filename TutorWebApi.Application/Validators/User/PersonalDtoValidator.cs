using FluentValidation;

namespace TutorWebApi.Application
{
    public class PersonalDtoValidator : AbstractValidator<PersonalDto>
    {
        public PersonalDtoValidator()
        {
            RuleFor(r => r.FirstName)
                .NotEmpty().WithMessage("First name can not be empty")
                .MaximumLength(25).WithMessage("First name can not have more letters than 25");

            RuleFor(r => r.LastName)
                .NotEmpty().WithMessage("Last name can not be empty")
                .MaximumLength(25).WithMessage("Last name can not have more letters than 25");

            RuleFor(r => r.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth can not be empty");
        }
    }
}
