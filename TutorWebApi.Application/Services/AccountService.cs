using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TutorWebApi.Domain;

namespace TutorWebApi.Application
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IUserRepository _userRepository;
        public AccountService(IMapper mapper, IPasswordHasher<User> passwordHasher, IUserRepository userRepository)
        {
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
        }

        public Task<string> AuthenticateUserAsync(LoginDto loginDto)
        {
            var user = _userRepository.GetUserByMail(loginDto.Mail);
            if (user is null)
                throw new BadRequestException("Invalid username or password");

            var password = _passwordHasher.VerifyHashedPassword(user, user.Password, loginDto.Password);
            if(password == PasswordVerificationResult.Failed)
                throw new BadRequestException("Invalid username or password");

            throw new NotImplementedException();
        }

        public async Task RegisterUserAsync(RegisterDto registerDto)
        {
            var user = _mapper.Map<User>(registerDto);
            var password = _passwordHasher.HashPassword(user, registerDto.Password);
            user.Password = password;
            
            await _userRepository.RegisterUserAsync(user);
        }
    }
}
