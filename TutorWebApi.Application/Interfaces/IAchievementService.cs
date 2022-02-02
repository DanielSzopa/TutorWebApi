using TutorWebApi.Application.Models.Profile;
using TutorWebApi.Domain.Entities;

namespace TutorWebApi.Application.Interfaces
{
    public interface IAchievementService
    {
        Task CreateAchievement(AchievementDto achievementDto, int profileId);
        Task UpdateAchievement(AchievementDto achievementDto, int achievementId,int profileId);
        Task DeleteAchievement(int achievementId, int profileId);
        Task<Domain.Entities.Profile> GetProfileIfExist(int profileId);
    }
}
