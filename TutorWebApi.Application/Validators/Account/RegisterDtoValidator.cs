using FluentValidation;
using TutorWebApi.Infrastructure;

namespace TutorWebApi.Application
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator(TutorWebApiDbContext dbContext)
        {
            RuleFor(r => r.Password)
                .MinimumLength(8).WithMessage("Password have to have minimum 8 letters");

            RuleFor(r => r.ConfirmPassword)
                .Equal(r => r.Password)
                .WithMessage("Passwords are not equel");

            RuleFor(r => r.Mail)
                .Custom((value, context) =>
                {
                    var isEmailIsTaken = dbContext.Users.Any(u => u.Mail == value);
                    if (isEmailIsTaken)
                        context.AddFailure("Mail", "That email is taken");
                });

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
