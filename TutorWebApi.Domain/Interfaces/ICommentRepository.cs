namespace TutorWebApi.Domain
{
    public interface ICommentRepository
    {
        Task<int> CreateComment(Comment comment);
    }
}
