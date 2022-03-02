using FluentValidation;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.Role;

namespace TutorWebApi.Application.Validators.Role
{
    public class ChangeRoleRequestDtoValidator : AbstractValidator<ChangeRoleRequestDto>
    {
        private IEnumerable<string> Roles = new List<string>();
        private bool result;
        public ChangeRoleRequestDtoValidator(IRoleService roleService)
        {
            RuleFor(r => r.Role)
                .MustAsync(async (value, cancelation) =>
                {
                    Roles = await roleService.GetRolesNames();
                    bool isRolesContain = Roles.Contains(value);
                    result = isRolesContain;
                    return isRolesContain;
                })
                .Custom((value, context) =>
                {
                    if (!result)
                        context.AddFailure(nameof(ChangeRoleRequestDto.Role), $"Role must be in [{string.Join(",", Roles)}]");
                });

            RuleFor(r => r.UserId)
                .NotEmpty()
                .WithMessage("UserId can not be empty");
        }
    }
}
