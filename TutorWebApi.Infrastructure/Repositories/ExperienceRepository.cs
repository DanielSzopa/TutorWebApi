using Microsoft.EntityFrameworkCore;
using TutorWebApi.Domain.Entities;
using TutorWebApi.Domain.Interfaces;
using TutorWebApi.Infrastructure.Context;

namespace TutorWebApi.Infrastructure.Repositories
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly TutorWebApiDbContext _dbContext;

        public ExperienceRepository(TutorWebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateExperience(Experience experience)
        {
            await _dbContext.Experiences.AddAsync(experience);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateExperience(Experience experience, int experienceId)
        {
            var result = await _dbContext.Experiences
                .FirstOrDefaultAsync(a => a.Id == experienceId);
            result.Description = experience.Description;
            await _dbContext.SaveChangesAsync();
        }


        public async Task DeleteExperience(int experienceId)
        {
            var experience = await _dbContext.Experiences
                  .FirstOrDefaultAsync(a => a.Id == experienceId);

            _dbContext.Experiences.Remove(experience);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Experience> GetExperienceById(int experienceId)
        {
            var experience = await _dbContext.Experiences
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == experienceId);
            return experience;
        }
    }
}
