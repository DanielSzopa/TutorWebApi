using Microsoft.EntityFrameworkCore;
using TutorWebApi.Domain.Entities;
using TutorWebApi.Domain.Interfaces;
using TutorWebApi.Infrastructure.Context;

namespace TutorWebApi.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly TutorWebApiDbContext _dbContext;

        public RoleRepository(TutorWebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            var roles = await _dbContext.Roles.ToListAsync();
            return roles;
        }
    }
}
