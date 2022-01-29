using System.Linq;

namespace TutorWebApi.Domain
{
    public interface ICommentRepository
    {
        Task<int> CreateComment(Comment comment);
        Task<Comment> GetCommentById(int commentId);
        IQueryable<Comment> GetAllComments(int profileId);
        Task UpdateComment(Comment comment);
    }
}
