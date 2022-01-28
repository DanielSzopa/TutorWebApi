namespace TutorWebApi.Domain
{
    public interface IUserRepository
    {
        Task<int> RegisterUserAsync(User user);
        Task SetCreateIdByAddress(int userId);
        Task<User> GetUserByMail(string mail);
        Task UpdateAddress(Address address, int userId);
        Task<Address> GetAddressByUserId(int userId);

    }
}
