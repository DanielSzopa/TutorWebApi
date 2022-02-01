using AutoMapper;
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

        public AchievementService(IAchievementRepository achievementRepository, IProfileRepository profileRepository,
            IMapper mapper,
            IUserContextService userContextService)
        {
            _achievementRepository = achievementRepository;
            _profileRepository = profileRepository;
            _mapper = mapper;
            _userContextService = userContextService;
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

        public async Task<Domain.Entities.Profile> GetProfileIfExist(int profileId)
        {
            var profile = await _profileRepository.GetProfileById(profileId);
            if (profile is null || profile.IsActive == false)
                throw new NotFoundException("Profile not found");

            return profile;
        }
    }
}
