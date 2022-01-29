namespace TutorWebApi.Application
{
    public interface ICommentService
    {
        Task<int> CreateComment(CommentDto commentDto, int profileId);
    }
}
