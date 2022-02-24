using TutorWebApi.Application.Models.Role;

namespace TutorWebApi.Application.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetAllRoles();
    }
}
