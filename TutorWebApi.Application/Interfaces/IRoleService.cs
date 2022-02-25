using TutorWebApi.Application.Models.Role;

namespace TutorWebApi.Application.Interfaces
{
    public interface IRoleService
    {
        Task UpdateRole(ChangeRoleRequestDto request);
        Task<IEnumerable<RoleDto>> GetAllRoles();
        Task<IEnumerable<string>> GetRolesNames();
    }
}
