using AutoMapper;
using TutorWebApi.Application.Authorization;
using TutorWebApi.Application.Exceptions;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.Profile;
using TutorWebApi.Domain.Entities;
using TutorWebApi.Domain.Interfaces;

namespace TutorWebApi.Application.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;
        private readonly IProfileRepository _profileRepository;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly IResourceOperationService<Experience> _resourceOperationService;

        public ExperienceService(IExperienceRepository experienceRepository, IProfileRepository profileRepository,
            IMapper mapper,
            IUserContextService userContextService,
            IResourceOperationService<Experience> resourceOperationService)
        {
            _experienceRepository = experienceRepository;
            _profileRepository = profileRepository;
            _mapper = mapper;
            _userContextService = userContextService;
            _resourceOperationService = resourceOperationService;
        }

        public async Task CreateExperience(ExperienceDto experienceDto, int profileId)
        {
            var profile = await GetProfileIfExist(profileId);
            var userId = await _userContextService.GetUserId();
            if (profile.CreateById != userId)
                throw new ForbidException("");

            var experience = _mapper.Map<Experience>(experienceDto);
            experience.ProfileId = profileId;

            await _experienceRepository.CreateExperience(experience);
        }

        public async Task UpdateExperience(ExperienceDto experienceDto, int experienceId, int profileId)
        {
            var profile = await GetProfileIfExist(profileId);
            var user = await _userContextService.GetUser();

            var experience = await _experienceRepository.GetExperienceById(experienceId);
            if (experience is null || experience.IsActive == false)
                throw new NotFoundException("Experience not found");

            await _resourceOperationService.ResourceAuthorizationException
                (user, experience, new ResourceOperationRequirement(ResourceOperation.Update));

            var newExperience = _mapper.Map<Experience>(experienceDto);
            await _experienceRepository.UpdateExperience(newExperience, experienceId);
        }

        public async Task DeleteExperience(int experienceId, int profileId)
        {
            var profile = await GetProfileIfExist(profileId);
            var user = await _userContextService.GetUser();

            var experience = await _experienceRepository.GetExperienceById(experienceId);
            if (experience is null || experience.IsActive == false)
                throw new NotFoundException("Experience not found");

            await _resourceOperationService.ResourceAuthorizationException
                (user, experience, new ResourceOperationRequirement(ResourceOperation.Delete));

            await _experienceRepository.DeleteExperience(experienceId);
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
