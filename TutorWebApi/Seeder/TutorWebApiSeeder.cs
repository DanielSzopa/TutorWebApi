using TutorWebApi.Domain.Entities;
using TutorWebApi.Infrastructure.Context;

namespace TutorWebApi.Seeder
{
    public class TutorWebApiSeeder
    {
        private readonly TutorWebApiDbContext _dbContext;

        public TutorWebApiSeeder(TutorWebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Subjects.Any())
                {
                    var subjects = GetSubjects();
                    await _dbContext.AddRangeAsync(subjects);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<Subject> GetSubjects()
        {
            var subjects = new List<Subject>()
            {
                new Subject { Name = "Polish" },
                new Subject { Name = "English" },
                new Subject { Name = "French" },
                new Subject { Name = "German" },
                new Subject { Name = "Front-end Programming" },
                new Subject { Name = "Back-End Programming" },
                new Subject { Name = "Database" },
                new Subject { Name = "Maths" },
                new Subject { Name = "Physics" },
                new Subject { Name = "Chemistry" },
                new Subject { Name = "Geography" },
                new Subject { Name = "History" },
                new Subject { Name = "Science" },
                new Subject { Name = "Art" },
                new Subject { Name = "It" },
                new Subject { Name = "Technology" },
                new Subject { Name = "Business Studies" }
            };

            return subjects;

        }
    }
}
