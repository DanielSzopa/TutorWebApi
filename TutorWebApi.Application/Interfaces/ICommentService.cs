using TutorWebApi.Application.Models.Comment;
using TutorWebApi.Domain.Entities;

namespace TutorWebApi.Application.Interfaces
{
    public interface ICommentService
    {
        Task<int> CreateComment(NewCommentDto commentDto, int profileId);
        Task<IEnumerable<CommentDto>> GetAllComments(int profileId);
        Task<CommentDto> GetCommentById(int profileId, int commentId);
        Task UpdateComment(NewCommentDto commentDto, int commentId, int profileId);
        Task DeleteComment(int profileId, int commentId);
        Task<Profile> GetProfileIfExist(int profileId);
        Task<Comment> GetCommentIfExist(int commentId);
    }
}
