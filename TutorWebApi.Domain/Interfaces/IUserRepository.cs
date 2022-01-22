namespace TutorWebApi.Domain
{
    public interface IUserRepository
    {
        Task RegisterUserAsync(User user);
        User GetUserByMail(string mail);
    }
}
