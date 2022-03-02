using FluentValidation;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.Account;

namespace TutorWebApi.Application.Validators.Account
{
    public class ChangePasswordRequestDtoValidator : AbstractValidator<ChangePasswordRequestDto>
    {
        public ChangePasswordRequestDtoValidator(IAccountService accountService)
        {
            RuleFor(r => new { r.Mail, r.Password })
                .MustAsync(async (value, cancellation) =>
                {
                    bool result = await accountService.IsUserCanLogin(value.Mail, value.Password);
                    return result;
                })
                .WithMessage("Invalid username or password");

            RuleFor(r => r.NewPassword)
                .MinimumLength(8).WithMessage("Password have to have minimum 8 letters");

            RuleFor(r => r.ConfirmNewPassword)
                .Equal(r => r.NewPassword)
                .WithMessage("Passwords are not equel");
        }
    }
}
