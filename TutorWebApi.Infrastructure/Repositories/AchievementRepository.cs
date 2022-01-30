using TutorWebApi.Domain;

namespace TutorWebApi.Infrastructure
{
    public class AchievementRepository : IAchievementRepository
    {
        private readonly TutorWebApiDbContext _dbContext;

        public AchievementRepository(TutorWebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
