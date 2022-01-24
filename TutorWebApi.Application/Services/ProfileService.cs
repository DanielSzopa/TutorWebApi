﻿using AutoMapper;
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

        public async Task<int> CreateProfile(ProfileDto profilDto)
        {
            var userId = (int)_userContextService.GetUserId();
            var result = _profileRepository.IsUserHaveProfile(userId).Result;
            if (result)
                throw new ForbidException("It is forbidden to create a second profile");

            var profile = _mapper.Map<Domain.Profile>(profilDto);
            profile.UserRef = userId;
            var profileId = await _profileRepository.CreateProfile(profile);

            return profileId;
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

            var authorizationResult = await _authorizationService.AuthorizeAsync(user, profile,
                new ResourceOperationRequirement(ResourceOperation.Delete));

            if(!authorizationResult.Succeeded)
            {
                throw new ForbidException("");
            }

            await _profileRepository.DeleteAllAchievementsByProfile(profileId);
            await _profileRepository.DeleteAllExperiencesByProfile(profileId);
            await _profileRepository.DeleteProfile(profileId);
        }
    }
}
