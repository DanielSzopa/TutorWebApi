using TutorWebApi.Application.Models.Account;

namespace TutorWebApi.Application.Interfaces
{
    public interface IAccountService
    {
        Task<string> AuthenticateUserAsync(LoginDto loginDto);
        Task RegisterUserAsync(RegisterDto registerDto);
        Task ChangePassword(ChangePasswordRequestDto changePasswordRequestDto);
        Task<bool> IsUserCanLogin(string mail, string password);
        string GenerateJwt(UserForJwtDto userForJwtDto);
    }
}
