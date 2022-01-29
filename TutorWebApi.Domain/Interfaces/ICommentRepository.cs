namespace TutorWebApi.Domain
{
    public interface ICommentRepository
    {
        Task<int> CreateComment(Comment comment);
        Task<Comment> GetCommentById(int commentId);
        Task UpdateComment(Comment comment);
    }
}
