namespace TutorWebApi.Domain
{
    public interface ILikeRepository
    {
        Task CreateLike(Like like);
        Task DeleteLike(Like like);
        Task<bool> IsUserCanLikeThisProfile(int profileId, int userId);
    }
}
