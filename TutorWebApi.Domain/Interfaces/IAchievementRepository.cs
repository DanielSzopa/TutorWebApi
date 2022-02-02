using TutorWebApi.Domain.Entities;

namespace TutorWebApi.Domain.Interfaces
{
    public interface IAchievementRepository
    {
        Task CreateAchievement(Achievement achievement);
        Task UpdateAchievement(Achievement achievement, int achievementId);
        Task DeleteAchievement(int achievementId);
        Task<Achievement> GetAchievementById(int achievementId);
    }
}
