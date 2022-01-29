using TutorWebApi.Domain;

namespace TutorWebApi.Application
{
    public interface ICommentService
    {
        Task<int> CreateComment(NewCommentDto commentDto, int profileId);
        Task UpdateComment(NewCommentDto commentDto, int commentId, int profileId);
        Task<IEnumerable<CommentDto>> GetAllComments(int profileId);
        Task<Profile> GetProfileIfExist(int profileId);
        Task<Comment> GetCommentIfExist(int commentId);
    }
}
