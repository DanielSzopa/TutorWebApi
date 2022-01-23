using TutorWebApi.Domain;

namespace TutorWebApi.Infrastructure
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly TutorWebApiDbContext _context;
        public ProfileRepository(TutorWebApiDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateProfile(Profile profile)
        {
            await _context.Profiles
               .AddAsync(profile);
            await _context.SaveChangesAsync();

            return profile.Id;
        }

        public async Task<bool> IsUserHaveProfile(int userId)
        {
            var result = _context.Profiles
                  .Any(p => p.UserRef == userId);
            return result;
        }
    }
}
