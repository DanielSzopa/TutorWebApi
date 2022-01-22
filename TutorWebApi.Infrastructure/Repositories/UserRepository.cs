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

        public async Task RegisterUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public User GetUserByMail(string mail)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Mail == mail);

            return user;
        }
    }
}
