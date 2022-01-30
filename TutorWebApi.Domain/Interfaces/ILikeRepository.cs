namespace TutorWebApi.Domain
{
    public interface ILikeRepository
    {
        Task CreateLike(Like like);
        Task DeleteLike(Like like);
        Task UpdateLike(Like like);
        Task<Like> GetLike(int profileId, int userId);
        Task<int> CountLikesByProfil(int profileId);
        Task<List<Like>> GetAllActiveLikes(int profileId);
        Task<bool> IsUserCanLikeThisProfile(int profileId, int userId);
    }
}
