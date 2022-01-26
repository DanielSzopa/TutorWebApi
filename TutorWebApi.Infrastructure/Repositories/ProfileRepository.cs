using Microsoft.EntityFrameworkCore;
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

        public async Task<int> UpdateProfile(Profile profile)
        {
            var newProfile = await _context.Profiles
                .Include(p => p.Achievements)
                .Include(p => p.Experiences)
                .FirstOrDefaultAsync(p => p.Id == profile.Id);
                

            newProfile.Description = profile.Description;
            newProfile.Achievements = profile.Achievements;
            newProfile.Experiences = profile.Experiences;

            await _context.SaveChangesAsync();
            return profile.Id;
        }

        public async Task<bool> IsUserHaveProfile(int userId)
        {
            var result = await _context.Profiles
                  .AnyAsync(p => p.UserRef == userId);
            return result;
        }

        public async Task<bool> IsProfileIsActive(int profileId)
        {
            var profile = await _context.Profiles
                .FirstOrDefaultAsync(p => p.Id == profileId);
                
            if(profile.IsActive)
                return true;
            else
                return false;
        }

        public async Task<Profile> GetProfileById(int profileId)
        {
            var profile = await _context.Profiles
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == profileId);

            return profile;
        }

        public async Task<Profile> GetFullProfileById(int profileId)
        {
            var profile = await _context.Profiles
                .Include(p => p.User)
                .ThenInclude(u => u.Address)
                .Include(p =>p.Achievements.Where(a => a.IsActive == true))
                .Include(p => p.Experiences.Where(e => e.IsActive == true))
                .FirstOrDefaultAsync(p => p.Id ==profileId && p.IsActive);

            return profile;
                               
        }

        public async Task<int> GetProfileIdByUser(int userId)
        {
            var profile = await _context.Profiles
                .FirstOrDefaultAsync(p => p.UserRef == userId);

            return profile.Id;
        }

        public async Task DeleteAllAchievementsByProfile(int profileId)
        {
            var achievements = _context.Achievements
                .Where(a => a.ProfilId == profileId);
            if (await achievements.AnyAsync())
            {
                _context.Achievements.RemoveRange(achievements);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAllExperiencesByProfile(int profileId)
        {
            var experiences = _context.Experiences
                .Where(a => a.ProfileId == profileId);
            if (await experiences.AnyAsync())
            {
                _context.Experiences.RemoveRange(experiences);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProfile(int profileId)
        {
            var profile = await _context.Profiles
                .Include(p => p.Achievements)
                .Include(p => p.Experiences)
                .FirstOrDefaultAsync(p => p.Id == profileId);

            if (!(profile is null))
            {
                _context.Profiles.Remove(profile);
                await _context.SaveChangesAsync();
            }
        }

    }
}
