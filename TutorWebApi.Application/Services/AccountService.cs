using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TutorWebApi.Domain;

namespace TutorWebApi.Application
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly AuthenticationSettings _authenticationSettings;
        public AccountService(IMapper mapper, IPasswordHasher<User> passwordHasher, IUserRepository userRepository
            ,AuthenticationSettings authenticationSettings)
        {
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _authenticationSettings = authenticationSettings;
        }

        public async Task<string> AuthenticateUserAsync(LoginDto loginDto)
        {
            var message = "Invalid username or password";
            var user = await _userRepository.GetUserByMail(loginDto.Mail);
            if (user is null)
                throw new BadRequestException(message);

            var password = _passwordHasher.VerifyHashedPassword(user, user.Password, loginDto.Password);
            if(password == PasswordVerificationResult.Failed)
                throw new BadRequestException(message);

            var userForJwt = _mapper.Map<UserForJwtDto>(user);
            var token = await GenerateJwt(userForJwt);

            return token;
        }
      
        public async Task RegisterUserAsync(RegisterDto registerDto)
        {
            var user = _mapper.Map<User>(registerDto);
            user.Mail = user.Mail.ToLower();
            var password = _passwordHasher.HashPassword(user, registerDto.Password);
            user.Password = password;
            
            var userId = await _userRepository.RegisterUserAsync(user);
            await _userRepository.SetCreateIdForUser(userId);
            await _userRepository.SetCreateIdForAddress(userId);
        }

        public async Task<string> GenerateJwt(UserForJwtDto userForJwtDto)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, userForJwtDto.Id.ToString()),
                new Claim(ClaimTypes.Name,$"{userForJwtDto.FirstName} {userForJwtDto.LastName}"),
                new Claim("Country", userForJwtDto.Country)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer, claims,
                expires: expires, signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}
