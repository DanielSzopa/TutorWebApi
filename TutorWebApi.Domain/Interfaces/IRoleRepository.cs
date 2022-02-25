using TutorWebApi.Domain.Entities;

namespace TutorWebApi.Domain.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllRoles();
        Task UpdateRole(int userId, string role);
    }
}
