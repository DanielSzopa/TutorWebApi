using TutorWebApi.Domain.Entities;

namespace TutorWebApi.Domain.Interfaces
{
    public interface ICommentRepository
    {
        Task<int> CreateComment(Comment comment);
        Task<Comment> GetCommentById(int commentId);
        Task<List<Comment>> GetAllActiveComments(int profileId);
        Task UpdateComment(Comment comment);
        Task DeleteComment(int commentId);
    }
}
