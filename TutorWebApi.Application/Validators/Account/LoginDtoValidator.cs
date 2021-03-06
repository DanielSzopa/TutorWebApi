using FluentValidation;
using TutorWebApi.Application.Models.Account;

namespace TutorWebApi.Application.Validators.Account
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(l => l.Mail)
                .NotEmpty().WithMessage("Mail can not be empty")
                .EmailAddress().WithMessage("Mail is not correct");

            RuleFor(l => l.Password)
                .NotEmpty().WithMessage("Password can not be empty");
        }
    }
}
