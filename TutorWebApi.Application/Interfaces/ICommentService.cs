namespace TutorWebApi.Application
{
    public interface ICommentService
    {
        Task<int> CreateComment(CommentDto commentDto, int profileId);
        Task UpdateComment(CommentDto commentDto, int commentId, int profileId);
    }
}
