using TutorWebApi.Domain.Interfaces;
using TutorWebApi.Infrastructure.Context;

namespace TutorWebApi.Infrastructure.Repositories
{
    public class AdvertRepository : IAdvertRepository
    {
        private readonly TutorWebApiDbContext _dbContext;

        public AdvertRepository(TutorWebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
