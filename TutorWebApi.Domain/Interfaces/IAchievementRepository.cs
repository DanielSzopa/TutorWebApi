using TutorWebApi.Domain.Entities;

namespace TutorWebApi.Domain.Interfaces
{
    public interface IAchievementRepository
    {
        Task CreateAchievement(Achievement achievement);
    }
}
