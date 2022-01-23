namespace TutorWebApi.Domain
{
    public interface IProfileRepository
    {
        Task<int> CreateProfile(Profile profile);
        Task<bool> IsUserHaveProfile(int userId);
    }
}
