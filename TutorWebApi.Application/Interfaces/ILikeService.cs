using TutorWebApi.Domain;

namespace TutorWebApi.Application
{
    public interface ILikeService
    {
        Task Like(int profileId);
        Task<Profile> GetProfileIfExist(int profileId);
    }
}
