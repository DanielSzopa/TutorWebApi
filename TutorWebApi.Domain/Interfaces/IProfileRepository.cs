namespace TutorWebApi.Domain
{
    public interface IProfileRepository
    {
        Task<int> CreateProfile(Profile profile);
        Task<bool> IsUserHaveProfile(int userId);
        Task<int> GetProfilIdByUser(int userId);
        Task<Profile> GetProfileById(int profileId);
        //ICollection<Task<Achievement>> GetAllAchievements(int profileId);
        //ICollection<Task<Experience>> GetAllExperiences(int profileId);
        Task DeleteProfile(int profileId);
        Task DeleteAllAchievementsByProfile(int profileId);
        Task DeleteAllExperiencesByProfile(int profileId);
    }
}
