using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TutorWebApi.Domain;

namespace TutorWebApi.Application
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;
        public AccountService(IMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }
        public async Task RegisterUser(RegisterDto registerDto)
        {
            var user = _mapper.Map<User>(registerDto);
            //throw exception invalid passwordHasing
            var password = _passwordHasher.HashPassword(user, registerDto.Password);

            user.Password = password;

            Console.WriteLine(user);
        }
    }
}
