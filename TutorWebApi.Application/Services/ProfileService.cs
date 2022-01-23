using AutoMapper;
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

        public ProfileService(IProfileRepository profileRepository, IUserContextService userContextService
            , IMapper mapper, ILogger<ProfileService> logger)
        {
            _profileRepository = profileRepository;
            _userContextService = userContextService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> CreateProfile(ProfileDto profilDto)
        {
            var userId = (int)_userContextService.GetUserId();
            var result = _profileRepository.IsUserHaveProfile(userId).Result;
            if (result)
                throw new BadRequestForCreateException("It is forbidden to create a second profile");

            var profile = _mapper.Map<Domain.Profile>(profilDto);
            profile.UserRef = userId;
            var profileId = await _profileRepository.CreateProfile(profile);

            return profileId;
        }

        public async Task DeleteProfile()
        {
            var userId = (int)_userContextService.GetUserId();
            _logger.LogInformation($"Profile with userRef:{userId} Delete action invoked");

            var result = await _profileRepository.IsUserHaveProfile(userId);
            if (!result)
                throw new NotFoundException("User does not have Profile");

            var profileId = await _profileRepository.GetProfilIdByUser(userId);

            await _profileRepository.DeleteAllAchievementsByProfile(profileId);
            await _profileRepository.DeleteAllExperiencesByProfile(profileId);
            await _profileRepository.DeleteProfile(profileId);
        }
    }
}
