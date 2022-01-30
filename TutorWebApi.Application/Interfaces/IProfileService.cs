using System.Security.Claims;
using TutorWebApi.Domain;

namespace TutorWebApi.Application
{
    public interface IProfileService
    {
        Task<int> CreateProfile(ProfileDto profileDto);
        Task<FullProfileDto> GetProfile(int profileId);
        Task<IEnumerable<SmallProfileDto>> GetAllSmallProfiles();
        Task<int> UpdateProfile(ProfileDto profileDto, int profileId);
        Task<int> UpdateProfileDescription(string description, int profileId);
        Task DeleteProfile(int profileId);
        Task<Profile> GetProfileIfExist(int profileId);

    }
}
