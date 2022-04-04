using Microsoft.EntityFrameworkCore;
using TutorWebApi.Domain.Entities;
using TutorWebApi.Domain.Interfaces;
using TutorWebApi.Infrastructure.Context;

namespace TutorWebApi.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TutorWebApiDbContext _context;

        public UserRepository(TutorWebApiDbContext context)
        {
            _context = context;
        }

        public async Task<int> RegisterUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }
        public async Task SetCreateIdForAddress(int userId)
        {
            var address = await _context.Addresses
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.UserRef == userId);
            address.CreateDate = address.User.CreateDate;
            address.CreateById = userId;

            await _context.SaveChangesAsync();
        }

        public async Task SetCreateIdForUser(int userId)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);
            user.CreateById = userId;

            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByMail(string mail)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Mail == mail);

            return user;
        }

        public async Task<User> GetUserWithRoleAndAddressByMail(string mail)
        {
            var user = await _context.Users
                .Include(u => u.Address)
                .Include(u => u.Role)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Mail == mail);

            return user;
        }

        public async Task<User> GetUserById(int userId)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == userId);

            return user;
        }

        public async Task UpdateAddress(Address address, int userId)
        {
            var result = await _context.Addresses
                .FirstOrDefaultAsync(a => a.UserRef == userId);

            result.Country = address.Country;
            result.City = address.City;
            result.PosteCode = address.PosteCode;
            result.Street = address.Street;
            result.AccommodationNumber = address.AccommodationNumber;

            await _context.SaveChangesAsync();
        }


        public async Task UpdatePersonal(User user)
        {
            var result = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == user.Id);

            result.FirstName = user.FirstName;
            result.LastName = user.LastName;
            result.DateOfBirth = user.DateOfBirth;

            await _context.SaveChangesAsync();
        }

        public async Task ChangePassword(string password, int userId)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);
            user.Password = password;
            await _context.SaveChangesAsync();
        }

        public async Task<Address> GetAddressByUserId(int userId)
        {
            var address = await _context.Addresses
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.UserRef == userId);
            return address;
        }

        public async Task<bool> IsMailIsTaken(string mail)
        {
            var result = await _context.Users
                .AnyAsync(u => u.Mail == mail);
            return result;
        }

        public async Task<IEnumerable<User>> GetAllUsers(string searchPhrase)
        {
            var users = await _context.Users
               .Include(u => u.Address)
               .Include(u => u.Role)
               .Where(p => searchPhrase == null ||
                ((p.FirstName + " " + p.LastName).ToLower().Contains(searchPhrase.ToLower()) ||
                p.Address.City.ToLower().Contains(searchPhrase.ToLower())))
               .AsNoTracking()
               .ToListAsync();

            return users;
        }
    }
}
