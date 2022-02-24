using AutoMapper;
using Microsoft.Extensions.Logging;
using TutorWebApi.Application.Authorization;
using TutorWebApi.Application.Exceptions;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.Profile;
using TutorWebApi.Domain.Entities;
using TutorWebApi.Domain.Interfaces;

namespace TutorWebApi.Application.Services
{
    public class AchievementService : IAchievementService
    {
        private readonly IAchievementRepository _achievementRepository;
        private readonly IProfileRepository _profileRepository;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly IResourceOperationService<Achievement> _resourceOperationService;
        private readonly ILogger<AchievementService> _logger;

        public AchievementService(IAchievementRepository achievementRepository, IProfileRepository profileRepository,
            IMapper mapper,
            IUserContextService userContextService,
            IResourceOperationService<Achievement> resourceOperationService,
             ILogger<AchievementService> logger)
        {
            _achievementRepository = achievementRepository;
            _profileRepository = profileRepository;
            _mapper = mapper;
            _userContextService = userContextService;
            _resourceOperationService = resourceOperationService;
            _logger = logger;
        }

        public async Task CreateAchievement(AchievementDto achievementDto, int profileId)
        {
            var profile = await GetProfileIfExist(profileId);
            var userId = await _userContextService.GetUserId();
            if (profile.CreateById != userId)
                throw new ForbidException("");

            var achievement = _mapper.Map<Achievement>(achievementDto);
            achievement.ProfilId = profileId;

            await _achievementRepository.CreateAchievement(achievement);
        }

        public async Task UpdateAchievement(AchievementDto achievementDto, int achievementId, int profileId)
        {
            var profile = await GetProfileIfExist(profileId);
            var user = await _userContextService.GetUser();

            var achievement = await _achievementRepository.GetAchievementById(achievementId);
            if (achievement is null || achievement.IsActive == false)
                throw new NotFoundException("Achievement not found");

            await _resourceOperationService.ResourceAuthorizationException
                (user, achievement, new ResourceOperationRequirement(ResourceOperation.Update));

            var newAchievement = _mapper.Map<Achievement>(achievementDto);
            await _achievementRepository.UpdateAchievement(newAchievement,achievementId);
        }

        public async Task DeleteAchievement(int achievementId, int profileId)
        {            
            var profile = await GetProfileIfExist(profileId);
            var userId = await _userContextService.GetUserId();
            _logger.LogInformation($"Achievement with id: {achievementId} DELETE action invoked by user with id: {userId}");

            var user = await _userContextService.GetUser();           
            var achievement = await _achievementRepository.GetAchievementById(achievementId);
            if (achievement is null || achievement.IsActive == false)
                throw new NotFoundException("Achievement not found");

            await _resourceOperationService.ResourceAuthorizationException
                (user, achievement, new ResourceOperationRequirement(ResourceOperation.Delete));

            await _achievementRepository.DeleteAchievement(achievementId);
        }

        private async Task<Domain.Entities.Profile> GetProfileIfExist(int profileId)
        {
            var profile = await _profileRepository.GetProfileById(profileId);
            if (profile is null || profile.IsActive == false)
                throw new NotFoundException("Profile not found");

            return profile;
        }
    }
}
