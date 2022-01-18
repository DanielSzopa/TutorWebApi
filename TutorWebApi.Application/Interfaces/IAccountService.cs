namespace TutorWebApi.Application
{
    public interface IAccountService
    {
         Task RegisterUser(RegisterDto registerDto);
    }
}
