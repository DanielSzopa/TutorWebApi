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

        public async Task DeleteLike(Like like)
        {
            var result = await _dbContext.Likes
                .FirstOrDefaultAsync
                (l => l.ProfileId == like.ProfileId && l.UserId == like.UserId);

            if(!(result is null))
            {
                _dbContext.Likes.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateLike(Like like)
        {
            var result = await _dbContext.Likes
                .FirstOrDefaultAsync(l => l.Id == like.Id);

            result.IsActive = true;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Like> GetLike(int profileId, int userId)
        {
            var like = await _dbContext.Likes
                .FirstOrDefaultAsync
                (l => l.ProfileId == profileId && l.UserId == userId);

            return like;
        }

        public async Task<List<Like>> GetAllActiveLikes(int profileId)
        {
            var likes = await _dbContext.Likes
                .Include(l => l.User)
                .Where(l => l.IsActive == true && l.ProfileId == profileId)
                .ToListAsync();
            return likes;
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
