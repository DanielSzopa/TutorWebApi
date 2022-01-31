using TutorWebApi.Domain.Interfaces;
using TutorWebApi.Infrastructure.Context;

namespace TutorWebApi.Infrastructure.Repositories
{
    public class AchievementRepository : IAchievementRepository
    {
        private readonly TutorWebApiDbContext _dbContext;

        public AchievementRepository(TutorWebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
