using TutorWebApi.Application.Models.Account;

namespace TutorWebApi.Application.Interfaces
{
    public interface IAccountService
    {
        Task<string> AuthenticateUserAsync(LoginDto loginDto);
        Task RegisterUserAsync(RegisterDto registerDto);
        Task<string> GenerateJwt(UserForJwtDto userForJwtDto);
    }
}
