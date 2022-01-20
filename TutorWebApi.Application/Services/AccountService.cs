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
        public async Task RegisterUser(RegisterDto registerDto)
        {
            var user = _mapper.Map<User>(registerDto);
            var password = _passwordHasher.HashPassword(user, registerDto.Password);
            user.Password = password;

            var 
           
        }
    }
}
