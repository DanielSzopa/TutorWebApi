using AutoMapper;
using TutorWebApi.Domain;

namespace TutorWebApi.Application
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        public AccountService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task RegisterUser(RegisterDto registerDto)
        {
            var user = _mapper.Map<User>(registerDto);
            Console.WriteLine(user);
        }
    }
}
