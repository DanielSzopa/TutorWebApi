using Microsoft.EntityFrameworkCore;
using TutorWebApi.Domain.Entities;
using TutorWebApi.Domain.Interfaces;
using TutorWebApi.Infrastructure.Context;

namespace TutorWebApi.Infrastructure.Repositories
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

        public async Task<int> UpdateProfileDescription(string description, int profileId)
        {
            var profile = await _context.Profiles
                .FirstOrDefaultAsync(p => p.Id == profileId);
            profile.Description = description;

            await _context.SaveChangesAsync();
            return profile.Id;
        }

        public async Task<bool> IsUserHaveProfile(int userId)
        {
            var result = await _context.Profiles
                .AsNoTracking()
                .AnyAsync(p => p.UserRef == userId);
            return result;
        }

        public async Task<bool> IsProfileIsActive(int profileId)
        {
            var profile = await _context.Profiles
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == profileId);

            if (profile.IsActive)
                return true;
            else
                return false;
        }

        public async Task<Profile> GetProfileById(int profileId)
        {
            var profile = await _context.Profiles
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == profileId);

            return profile;
        }

        public async Task<List<Profile>> GetAllProfiles(string searchPhrase)
        {
            var profiles = await _context.Profiles
                .Include(p => p.User)
                .ThenInclude(u => u.Address)
                .AsNoTracking()
                .Where(p => searchPhrase == null ||
                (p.User.FirstName + " " + p.User.LastName).ToLower().Contains(searchPhrase.ToLower())
                || p.Description.ToLower().Contains(searchPhrase.ToLower()))              
                .ToListAsync();

            return profiles;
        }

        public async Task<Profile> GetFullProfileById(int profileId)
        {
            var profile = await _context.Profiles
                .Include(p => p.User)
                .ThenInclude(u => u.Address)
                .Include(p => p.Achievements.Where(a => a.IsActive == true))
                .Include(p => p.Experiences.Where(e => e.IsActive == true))
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == profileId && p.IsActive);

            return profile;

        }

        public async Task<int> GetProfileIdByUser(int userId)
        {
            var profile = await _context.Profiles
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.UserRef == userId);

            return profile.Id;
        }

        public async Task<Profile> GetProfileByUserId(int userId)
        {
            var profile = await _context.Profiles
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.UserRef == userId);
            return profile;
        }      

        public async Task DeleteProfile(int profileId)
        {
            var profile = await _context.Profiles
                .Include(p => p.Achievements)
                .Include(p => p.Experiences)
                .Include(p => p.Likes)
                .Include(p => p.Comments)
                .Include(p => p.Adverts)
                .ThenInclude(a => a.AdvertContact)
                .FirstOrDefaultAsync(p => p.Id == profileId);

                _context.Profiles.Remove(profile);
                await _context.SaveChangesAsync();         
        }
    }
}
