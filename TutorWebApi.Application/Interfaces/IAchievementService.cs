using TutorWebApi.Application.Models.Profile;
using TutorWebApi.Domain.Entities;

namespace TutorWebApi.Application.Interfaces
{
    public interface IAchievementService
    {
        Task CreateAchievement(AchievementDto achievementDto, int profileId);
        Task<Domain.Entities.Profile> GetProfileIfExist(int profileId);
    }
}
