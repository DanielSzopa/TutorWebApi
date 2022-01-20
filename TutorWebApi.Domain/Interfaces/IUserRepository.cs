namespace TutorWebApi.Domain
{
    public interface IUserRepository
    {
        Task RegisterUser(User user);
    }
}
