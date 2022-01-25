using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using TutorWebApi.Domain;

namespace TutorWebApi.Application
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IUserContextService _userContextService;
        private readonly IMapper _mapper;
        private readonly ILogger<ProfileService> _logger;
        private readonly IAuthorizationService _authorizationService;

        public ProfileService(IProfileRepository profileRepository, IUserContextService userContextService
            , IMapper mapper, ILogger<ProfileService> logger, IAuthorizationService authorizationService)
        {
            _profileRepository = profileRepository;
            _userContextService = userContextService;
            _mapper = mapper;
            _logger = logger;
            _authorizationService = authorizationService;
        }

        public async Task<int> CreateProfile(ProfileDto profileDto)
        {
            var userId = (int)_userContextService.GetUserId();
            var result = _profileRepository.IsUserHaveProfile(userId).Result;
            var resultId = default(int);
            var mappedProfile = default(Domain.Profile);

            if(result)
            {
                var profileId = await _profileRepository.GetProfileIdByUser(userId);
                var isActive = await _profileRepository.IsProfileIsActive(profileId);
                if(isActive)
                    throw new ForbidException("It is forbidden to create a second profile");
                else
                {
                    mappedProfile = _mapper.Map<Domain.Profile>(profileDto);
                    mappedProfile.UserRef = userId;
                    mappedProfile.Id = profileId;
                    resultId = await _profileRepository.UpdateProfile(mappedProfile);
                    return resultId;
                }
            }
                               
            mappedProfile = _mapper.Map<Domain.Profile>(profileDto);
            mappedProfile.UserRef = userId;
            resultId = await _profileRepository.CreateProfile(mappedProfile);

            return resultId;
        }


        public async Task<FullProfileDto> GetProfile(int profileId)
        {
            var profile = await _profileRepository.GetFullProfileById(profileId);
            if(profile is null)
                throw new NotFoundException("Profile not found");

            var profileDto = _mapper.Map<FullProfileDto>(profile);
            return profileDto;
        }

        public async Task<int> UpdateProfile(ProfileDto profileDto, int profileId)
        {         
            var profile = await _profileRepository.GetProfileById(profileId);
            if (profile is null)
                throw new NotFoundException("Profile not found");

            var isActive = await _profileRepository.IsProfileIsActive(profileId);
            if (!isActive)
                throw new NotFoundException("Profile not found");

            var user = _userContextService.GetUser();
            var result = await _authorizationService.AuthorizeAsync(user, profile,
                new ResourceOperationRequirement(ResourceOperation.Update));
            if (!result.Succeeded)
                throw new ForbidException("");

            var updatedProfile = _mapper.Map<Domain.Profile>(profileDto);
            updatedProfile.Id = profileId;
            updatedProfile.UserRef = profile.UserRef;
            var resultId = await _profileRepository.UpdateProfile(updatedProfile);

            return resultId;
        }

        public async Task DeleteProfile(int profileId)
        {
            var user = _userContextService.GetUser();
            var userId = (int)_userContextService.GetUserId();
            _logger.LogInformation($"Profile id: {profileId} with userRef:{userId} Delete action invoked");

            var result = await _profileRepository.IsUserHaveProfile(userId);
            if (!result)
                throw new NotFoundException("User does not have Profile");

            var profile = await _profileRepository.GetProfileById(profileId);

            var isActive = await _profileRepository.IsProfileIsActive(profileId);
            if (!isActive)
                throw new NotFoundException("Profile not found");

            var authorizationResult = await _authorizationService.AuthorizeAsync(user, profile,
                new ResourceOperationRequirement(ResourceOperation.Delete));
            if(!authorizationResult.Succeeded)
                throw new ForbidException("");

            await _profileRepository.DeleteProfile(profileId);
        }
    }
}
