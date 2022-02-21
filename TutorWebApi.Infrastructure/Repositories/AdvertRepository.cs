﻿using Microsoft.EntityFrameworkCore;
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

        public async Task UpdateAdvert(Advert advert)
        {
            var entity = await _dbContext.Adverts
                .Include(a => a.AdvertContact)
                .FirstOrDefaultAsync(a => a.Id == advert.Id);

            entity.Title = advert.Title;
            entity.Description = advert.Description;
            entity.City = advert.City;
            entity.Price = advert.Price;
            entity.IsOnline = advert.IsOnline;
            entity.SubjectId = advert.SubjectId;
            entity.SubjectId = advert.SubjectId;
            entity.AdvertContact.Mail = advert.AdvertContact.Mail;
            entity.AdvertContact.Number = advert.AdvertContact.Number;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Advert> GetAdvertById(int id)
        {
            var advert = await _dbContext.Adverts
                .Include(a => a.AdvertContact)
                .Include(a => a.Subject)
                .Include(a => a.Profil)
                .ThenInclude(p => p.User)
                .FirstOrDefaultAsync(a => a.Id == id);
            return advert;
        }

        public async Task<List<Advert>> GetAllAdverts()
        {
            var adverts = await _dbContext.Adverts
                .Include(a => a.AdvertContact)
                .Include(a => a.Subject)
                .Include(a => a.Profil)
                .ThenInclude(p => p.User)
                .ToListAsync();

            return adverts;
        }
    }
}
