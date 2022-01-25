namespace TutorWebApi.Domain
{
    public interface IProfileRepository
    {
        Task<int> CreateProfile(Profile profile);
        Task<bool> IsUserHaveProfile(int userId);
        Task<bool> IsProfileIsActive(int profileId);
        Task<int> GetProfileIdByUser(int userId);
        Task<Profile> GetProfileById(int profileId);
        Task<Profile> GetFullProfileById(int profileId);
        Task<int> UpdateProfile(Profile profile);
        Task DeleteProfile(int profileId);
        Task DeleteAllAchievementsByProfile(int profileId);
        Task DeleteAllExperiencesByProfile(int profileId);
    }
}
