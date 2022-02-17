using TutorWebApi.Application.Models.Comment;
using TutorWebApi.Application.Models.Page;
using TutorWebApi.Domain.Entities;

namespace TutorWebApi.Application.Interfaces
{
    public interface ICommentService
    {
        Task<int> CreateComment(NewCommentDto commentDto, int profileId);
        Task<PagedResult<CommentDto>> GetAllComments(CommentQuery commentQuery,int profileId);
        Task<CommentDto> GetCommentById(int profileId, int commentId);
        Task UpdateComment(NewCommentDto commentDto, int commentId, int profileId);
        Task DeleteComment(int profileId, int commentId);
    }
}
