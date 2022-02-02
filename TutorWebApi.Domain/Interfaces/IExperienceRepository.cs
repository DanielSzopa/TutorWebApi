using TutorWebApi.Domain.Entities;

namespace TutorWebApi.Domain.Interfaces
{
    public interface IExperienceRepository
    {
        Task CreateExperience(Experience experience);
        Task UpdateExperience(Experience experience, int experienceId);
        Task DeleteExperience(int experienceId);
        Task<Experience> GetExperienceById(int experienceId);
    }
}
