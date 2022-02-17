using TutorWebApi.Application.Models.Like;
using TutorWebApi.Domain.Entities;

namespace TutorWebApi.Application.Interfaces
{
    public interface ILikeService
    {
        Task Like(int profileId);
        Task Unlike(int profileId);
        Task<IEnumerable<LikeDto>> GetAllLikes(int profileId);
    }
}
