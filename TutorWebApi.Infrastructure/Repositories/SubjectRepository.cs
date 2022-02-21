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

        public async Task UpdateSubject(Subject subject)
        {
            var entity = await _dbContext.Subjects
               .FindAsync(subject.Id);
            entity.Name = subject.Name;

            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteSubject(int subjectId)
        {
            var subject = await _dbContext.Subjects
              .FindAsync(subjectId);

            _dbContext.Subjects.Remove(subject);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Subject>> GetAllSubjects()
        {
            var subjects = await _dbContext.Subjects.ToListAsync();
            return subjects;
        }

        public async Task<Subject> GetSubjectById(int subjectId)
        {
            var subject = await _dbContext.Subjects
                .FirstOrDefaultAsync(s => s.Id == subjectId);
            return subject;
        }

        public async Task<Subject> GetSubjectByName(string subject)
        {
            var result = await _dbContext.Subjects
                .FirstOrDefaultAsync(s => s.Name == subject);
            return result;
        }

        public async Task ActiveSubject(int subjectId)
        {
            var subject = await _dbContext.Subjects
                .FindAsync(subjectId);
            subject.IsActive = true;
            await _dbContext.SaveChangesAsync();
        }
    }
}
