using TutorWebApi.Domain;

namespace TutorWebApi.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
           _userRepository = userRepository;
        }

        public async Task UpdateAddress(AddressDto addressDto, int userId)
        {
            var address = await _userRepository.GetAddressByUserId(userId);
            if (address is null || address.IsActive == false)
                throw new NotFoundException("");

            //sprawdz dostęp do zasobu (stworz resourcera)

        }
    }
}
