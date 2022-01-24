namespace TutorWebApi.Application
{
    public interface IProfileService
    {
        Task<int> CreateProfile(ProfileDto profileDto);
        Task DeleteProfile(int profileId);
    }
}
