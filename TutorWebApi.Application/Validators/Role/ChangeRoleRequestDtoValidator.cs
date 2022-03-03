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
                .CustomAsync(async (value, context, token) =>
                {
                    var roles = await roleService.GetRolesNames();
                    bool isRolesContain = roles.Contains(value);
                    if (!isRolesContain)
                        context.AddFailure(nameof(ChangeRoleRequestDto.Role), $"Role must be in [{string.Join(",", roles)}]");
                });

            RuleFor(r => r.UserId)
                .NotEmpty()
                .WithMessage("UserId can not be empty");
        }
    }
}
