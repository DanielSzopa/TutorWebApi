namespace TutorWebApi.Application
{
    public interface IAccountService
    {
        Task<string> AuthenticateUserAsync(LoginDto loginDto);
        Task RegisterUserAsync(RegisterDto registerDto);   
        Task<string> GenerateJwt(UserForJwtDto userForJwtDto);
    }
}
