using Microsoft.EntityFrameworkCore;
using TutorWebApi.Domain;

namespace TutorWebApi.Infrastructure
{
    public class CommentRepository : ICommentRepository
    {
        private readonly TutorWebApiDbContext _dbContext;

        public CommentRepository(TutorWebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateComment(Comment comment)
        {
            await _dbContext.Comments
               .AddAsync(comment);
            await _dbContext.SaveChangesAsync();

            return comment.Id;
        }

        public async Task<Comment> GetCommentById(int commentId)
        {
            var comment = await _dbContext.Comments
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == commentId);
            return comment;
        }

        public async Task<List<Comment>> GetAllActiveComments(int profileId)
        {
            var comments = await _dbContext.Comments
                .Include(c => c.User)
                .Where(c => c.ProfileId == profileId && c.IsActive == true)
                .ToListAsync();

            return comments;
        }

        public async Task UpdateComment(Comment comment)
        {
            var result = await _dbContext.Comments
                 .FirstOrDefaultAsync(c => c.Id == comment.Id);
            result.Description = comment.Description;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteComment(int commentId)
        {
            var comment = await _dbContext.Comments
                .FirstOrDefaultAsync(c => c.Id == commentId);
            if(!(comment is null))
                _dbContext.Comments.Remove(comment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
