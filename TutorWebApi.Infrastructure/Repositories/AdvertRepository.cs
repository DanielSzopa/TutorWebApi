using Microsoft.EntityFrameworkCore;
using TutorWebApi.Domain.Entities;
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

        public async Task<int> CreateAdvert(Advert advert)
        {
            await _dbContext.Adverts
                .AddAsync(advert);
            await _dbContext.SaveChangesAsync();
            return advert.Id;
        }

        public async Task<Advert> GetAdvertById(int id)
        {
            var advert = await _dbContext.Adverts
                .Include(a => a.AdvertContact)
                .Include(a => a.Profil)
                .ThenInclude(p => p.User)
                .FirstOrDefaultAsync(a => a.Id == id);
            return advert;
        }
    }
}
