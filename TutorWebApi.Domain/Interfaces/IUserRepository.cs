using TutorWebApi.Domain.Entities;

namespace TutorWebApi.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<int> RegisterUserAsync(User user);
        Task SetCreateIdForAddress(int userId);
        Task SetCreateIdForUser(int userId);
        Task<User> GetUserByMail(string mail);
        Task<User> GetUserWithRoleAndAddressByMail(string mail);
        Task<User> GetUserById(int userId);
        Task<IEnumerable<User>> GetAllUsers(string searchPhrase);
        Task UpdateAddress(Address address, int userId);
        Task UpdatePersonal(User user);
        Task ChangePassword(string password, int userId);
        Task<Address> GetAddressByUserId(int userId);
        Task<bool> IsMailIsTaken(string mail);

    }
}
