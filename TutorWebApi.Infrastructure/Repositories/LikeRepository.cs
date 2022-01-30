using Microsoft.EntityFrameworkCore;
using TutorWebApi.Domain;

namespace TutorWebApi.Infrastructure
{
    public class LikeRepository : ILikeRepository
    {
        private readonly TutorWebApiDbContext _dbContext;

        public LikeRepository(TutorWebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateLike(Like like)
        {
            await _dbContext.Likes
                .AddAsync(like);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsUserCanLikeThisProfile(int profileId, int userId)
        {
            var like = await _dbContext.Likes
                .FirstOrDefaultAsync(l => l.UserId == userId && l.ProfileId == profileId);

            if (like is null)
                return true;

            return false;
        }
    }
}
