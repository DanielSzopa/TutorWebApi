using TutorWebApi.Application.Models.Profile;

namespace TutorWebApi.Application.Interfaces
{
    public interface IExperienceService
    {
        Task CreateExperience(ExperienceDto experienceDto, int profileId);
        Task UpdateExperience(ExperienceDto experienceDto, int experienceId, int profileId);
        Task DeleteExperience(int experienceId, int profileId);
    }
}
