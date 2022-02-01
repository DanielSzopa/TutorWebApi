using AutoMapper;
using TutorWebApi.Application.Authorization;
using TutorWebApi.Application.Exceptions;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.User;
using TutorWebApi.Domain.Entities;
using TutorWebApi.Domain.Interfaces;

namespace TutorWebApi.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IResourceOperationService<Address> _resourceOperationServiceAddress;
        private readonly IResourceOperationService<User> _resourceOperationServiceUser;
        private readonly IUserContextService _userContextService;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IResourceOperationService<Address> resourceOperationServiceAddress,
             IResourceOperationService<User> resourceOperationServiceUser,
            IUserContextService userContextService, IMapper mapper)
        {
            _userRepository = userRepository;
            _resourceOperationServiceAddress = resourceOperationServiceAddress;
            _resourceOperationServiceUser = resourceOperationServiceUser;
            _userContextService = userContextService;
            _mapper = mapper;
        }

        public async Task UpdateAddress(AddressDto addressDto, int userId)
        {
            var address = await _userRepository.GetAddressByUserId(userId);
            if (address is null || address.IsActive == false)
                throw new NotFoundException("Address not found");

            var user = await _userContextService.GetUser();
            await _resourceOperationServiceAddress.ResourceAuthorizationException
                (user, address, new ResourceOperationRequirement(ResourceOperation.Update));

            var mappedAddress = _mapper.Map<Address>(addressDto);
            await _userRepository.UpdateAddress(mappedAddress, userId);
        }

        public async Task UpdatePersonal(PersonalDto personalDto, int userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user is null || user.IsActive == false)
                throw new NotFoundException("User not found");
            var userClaim = await _userContextService.GetUser();

            await _resourceOperationServiceUser.ResourceAuthorizationException
                (userClaim, user, new ResourceOperationRequirement(ResourceOperation.Update));

            var mappedUser = _mapper.Map<User>(personalDto);
            mappedUser.Id = userId;
            await _userRepository.UpdatePersonal(mappedUser);
        }

        public async Task<bool> IsMailIsTaken(string mail)
        {
            var result = await _userRepository.IsMailIsTaken(mail);
            return result;
        }
    }
}
