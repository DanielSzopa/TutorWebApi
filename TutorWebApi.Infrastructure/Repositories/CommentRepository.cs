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
            _dbContext.SaveChangesAsync();

            return comment.Id;
        }
    }
}
