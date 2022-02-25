using FluentValidation;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.Role;

namespace TutorWebApi.Application.Validators.Role
{
    public class ChangeRoleRequestDtoValidator : AbstractValidator<ChangeRoleRequestDto>
    {
        public ChangeRoleRequestDtoValidator(IRoleService roleService)
        {
            RuleFor(r => r.Role)
                .Custom((value, context) =>
                {
                    var roles = roleService.GetRolesNames().Result.ToList();
                    if(!(roles.Contains(value)))
                    {
                        var message = $"Role must be in [{String.Join(",", roles)}]";
                        context.AddFailure("Role", message);
                    }
                });

            RuleFor(r => r.UserId)
                .NotEmpty()
                .WithMessage("UserId can not be empty");
        }
    }
}
