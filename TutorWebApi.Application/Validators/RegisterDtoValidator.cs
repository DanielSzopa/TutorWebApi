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

            RuleFor(r => r.FirstName)
                .NotEmpty().WithMessage("First name can not be empty")
                .MaximumLength(25).WithMessage("First name can not have more letters than 25");

            RuleFor(r => r.LastName)
                .NotEmpty().WithMessage("Last name can not be empty")
                .MaximumLength(25).WithMessage("Last name can not have more letters than 25");

            RuleFor(r => r.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth can not be empty");

            RuleFor(r => r.Address.Country)
                 .NotEmpty().WithMessage("Country can not be empty")
                  .MaximumLength(50).WithMessage("Country can not have more letters than 50");

            RuleFor(r => r.Address.City)
                 .NotEmpty().WithMessage("City can not be empty")
                  .MaximumLength(50).WithMessage("City can not have more letters than 50");
        }
    }
}
