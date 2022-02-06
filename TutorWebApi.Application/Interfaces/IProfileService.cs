using TutorWebApi.Application.Models.Page;
using TutorWebApi.Application.Models.Profile;
using TutorWebApi.Domain.Entities;

namespace TutorWebApi.Application.Interfaces
{
    public interface IProfileService
    {
        Task<int> CreateProfile(ProfileDto profileDto);
        Task<FullProfileDto> GetProfile(int profileId);
        Task<PagedResult<SmallProfileDto>> GetAllSmallProfiles(ProfileQuery profileQuery);
        Task<int> UpdateProfile(ProfileDto profileDto, int profileId);
        Task<int> UpdateProfileDescription(string description, int profileId);
        Task DeleteProfile(int profileId);
        Task<Profile> GetProfileIfExist(int profileId);

    }
}
