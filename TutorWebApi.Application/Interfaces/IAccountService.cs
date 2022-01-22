namespace TutorWebApi.Application
{
    public interface IAccountService
    {
         Task RegisterUserAsync(RegisterDto registerDto);
         Task<string> AuthenticateUserAsync(LoginDto loginDto);
    }
}
