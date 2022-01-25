namespace TutorWebApi.Application
{
    public interface IProfileService
    {
        Task<int> CreateProfile(ProfileDto profileDto);
        Task<FullProfileDto> GetProfile(int profileId);
        Task<int> UpdateProfile(ProfileDto profileDto, int profileId);
        Task DeleteProfile(int profileId);      
    }
}
