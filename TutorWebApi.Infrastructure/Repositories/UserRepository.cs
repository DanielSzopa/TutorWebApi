using TutorWebApi.Domain;

namespace TutorWebApi.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly TutorWebApiDbContext _context;

        public UserRepository(TutorWebApiDbContext context)
        {
            _context = context;
        }

        public async Task RegisterUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
