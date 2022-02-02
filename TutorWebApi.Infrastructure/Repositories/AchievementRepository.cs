using Microsoft.EntityFrameworkCore;
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

        public async Task UpdateAchievement(Achievement achievement, int achievementId)
        {
            var result = await _dbContext.Achievements
                .FirstOrDefaultAsync(a => a.Id == achievementId);
            result.Description = achievement.Description;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAchievement(int achievementId)
        {
            var achievement = await _dbContext.Achievements
                 .FirstOrDefaultAsync(a => a.Id == achievementId);

            _dbContext.Achievements.Remove(achievement);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Achievement> GetAchievementById(int id)
        {
            var achievement = await _dbContext.Achievements
                .FirstOrDefaultAsync(a => a.Id == id);
            return achievement;
        }
    }
}
