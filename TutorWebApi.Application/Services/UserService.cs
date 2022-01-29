using AutoMapper;
using TutorWebApi.Domain;

namespace TutorWebApi.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IResourceOperationService<Address> _resourceOperationService;
        private readonly IUserContextService _userContextService;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IResourceOperationService<Address> resourceOperationService,
            IUserContextService userContextService, IMapper mapper)
        {
            _userRepository = userRepository;
            _resourceOperationService = resourceOperationService;
            _userContextService = userContextService;
            _mapper = mapper;
        }

        public async Task UpdateAddress(AddressDto addressDto, int userId)
        {
            var address = await _userRepository.GetAddressByUserId(userId);
            if (address is null || address.IsActive == false)
                throw new NotFoundException("Address not found");

            var user = await _userContextService.GetUser();
            await _resourceOperationService.ResourceAuthorizationException
                (user, address, new ResourceOperationRequirement(ResourceOperation.Update));

            var mappedAddress = _mapper.Map<Address>(addressDto);
            await _userRepository.UpdateAddress(mappedAddress, userId);
        }
    }
}
