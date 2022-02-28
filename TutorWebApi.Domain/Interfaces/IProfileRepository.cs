using TutorWebApi.Domain.Entities;

namespace TutorWebApi.Domain.Interfaces
{
    public interface IProfileRepository
    {
        Task<int> CreateProfile(Profile profile);
        Task<bool> IsUserHaveProfile(int userId);
        Task<bool> IsProfileIsActive(int profileId);
        Task<int> GetProfileIdByUser(int userId);
        Task<Profile> GetProfileById(int profileId);
        Task<Profile> GetProfileByUserId(int userId);
        Task<Profile> GetFullProfileById(int profileId);
        Task<List<Profile>> GetAllProfiles(string searchPhrase);
        Task<int> UpdateProfile(Profile profile);
        Task<int> UpdateProfileDescription(string description, int profileId);
        Task DeleteProfile(int profileId);
    }
}
