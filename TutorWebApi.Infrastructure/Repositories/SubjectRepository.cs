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

        public async Task<List<Subject>> GetAllSubjects()
        {
            var subjects = await _dbContext.Subjects.ToListAsync();
            return subjects;
        }
    }
}
