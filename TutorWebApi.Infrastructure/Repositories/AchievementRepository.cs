using TutorWebApi.Domain.Entities;
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

        public async Task CreateAchievement(Achievement achievement)
        {
            await _dbContext.Achievements.AddAsync(achievement);
            await _dbContext.SaveChangesAsync();
        }
    }
}
