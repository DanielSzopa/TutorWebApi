using FluentValidation;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.Account;
using TutorWebApi.Application.Validators.User;

namespace TutorWebApi.Application.Validators.Account
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator(IUserService userService)
        {
            RuleFor(r => r.Password)
                .MinimumLength(8).WithMessage("Password have to have minimum 8 letters");

            RuleFor(r => r.ConfirmPassword)
                .Equal(r => r.Password)
                .WithMessage("Passwords are not equel");

            RuleFor(r => r.Mail)
                .MustAsync(async (value, cancelation) =>
                {
                    bool isEmailIsTaken = await userService.IsMailIsTaken(value);
                    return !isEmailIsTaken;
                })
                .WithMessage("That email is taken");

            RuleFor(r => r.Mail)
                .NotEmpty().WithMessage("Mail can not be empty")
                .EmailAddress().WithMessage("Mail is not correct")
                .MaximumLength(100).WithMessage("Mail can not have more letters than 100");

            RuleFor(r => r.Personal)
                .SetValidator(new PersonalDtoValidator());

            RuleFor(r => r.Address)
                .SetValidator(new AddressDtoValidator());

        }
    }
}
