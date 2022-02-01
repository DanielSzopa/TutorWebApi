using TutorWebApi.Domain.Entities;

namespace TutorWebApi.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<int> RegisterUserAsync(User user);
        Task SetCreateIdForAddress(int userId);
        Task SetCreateIdForUser(int userId);
        Task<User> GetUserByMail(string mail);
        Task<User> GetUserById(int userId);
        Task UpdateAddress(Address address, int userId);
        Task UpdatePersonal(User user);
        Task<Address> GetAddressByUserId(int userId);
        Task<bool> IsMailIsTaken(string mail);

    }
}
