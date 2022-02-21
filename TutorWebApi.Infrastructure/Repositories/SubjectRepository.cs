using Microsoft.EntityFrameworkCore;
using TutorWebApi.Domain.Entities;
using TutorWebApi.Domain.Interfaces;
using TutorWebApi.Infrastructure.Context;

namespace TutorWebApi.Infrastructure.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly TutorWebApiDbContext _dbContext;

        public SubjectRepository(TutorWebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateSubject(Subject subject)
        {
            await _dbContext.Subjects.AddAsync(subject);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Subject>> GetAllSubjects()
        {
            var subjects = await _dbContext.Subjects.ToListAsync();
            return subjects;
        }

        public async Task<Subject> GetSubjectByName(string subject)
        {
            var result = await _dbContext.Subjects
                .FirstOrDefaultAsync(s => s.Name == subject);
            return result;
        }
    }
}
