using AutoMapper;
using Microsoft.Extensions.Logging;
using TutorWebApi.Application.Authorization;
using TutorWebApi.Application.Exceptions;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.Page;
using TutorWebApi.Application.Models.Profile;
using TutorWebApi.Domain.Interfaces;

namespace TutorWebApi.Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IUserContextService _userContextService;
        private readonly IMapper _mapper;
        private readonly ILogger<ProfileService> _logger;
        private readonly IResourceOperationService<Domain.Entities.Profile> _resourceOperationService;
        private readonly ILikeRepository _likeRepository;
        private readonly IPaginationService _paginationService;

        public ProfileService(IProfileRepository profileRepository, IUserContextService userContextService
            , IMapper mapper, ILogger<ProfileService> logger,
            IResourceOperationService<Domain.Entities.Profile> resourceOperationInterface,
            ILikeRepository likeRepository, IPaginationService paginationService)
        {
            _profileRepository = profileRepository;
            _userContextService = userContextService;
            _mapper = mapper;
            _resourceOperationService = resourceOperationInterface;
            _likeRepository = likeRepository;
            _paginationService = paginationService;
            _logger = logger;
        }

        public async Task<int> CreateProfile(ProfileDto profileDto)
        {
            var userId = await _userContextService.GetUserId();
            var result = await _profileRepository.IsUserHaveProfile(userId);
            var resultId = default(int);
            var mappedProfile = default(Domain.Entities.Profile);

            if(result)
            {
                var profileId = await _profileRepository.GetProfileIdByUser(userId);
                var isActive = await _profileRepository.IsProfileIsActive(profileId);
                if(isActive == true)
                    throw new ForbidException("It is forbidden to create a second profile");
                else
                {
                    mappedProfile = _mapper.Map<Domain.Entities.Profile>(profileDto);
                    mappedProfile.UserRef = userId;
                    mappedProfile.Id = profileId;
                    resultId = await _profileRepository.UpdateProfile(mappedProfile);
                    return resultId;
                }
            }
                               
            mappedProfile = _mapper.Map<Domain.Entities.Profile>(profileDto);
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

        public async Task<PagedResult<SmallProfileDto>> GetAllSmallProfiles(ProfileQuery profileQuery)
        {
            var profiles = await _profileRepository.GetAllProfiles(profileQuery.SearchPhrase);
            var mappedDtos = _mapper.Map<List<SmallProfileDto>>(profiles);

            if(!string.IsNullOrEmpty(profileQuery.SortBy))
            {
                var columnsSelectors = new Dictionary<string, Func<SmallProfileDto, object>>
                {
                    { nameof(SmallProfileDto.FullName), r => r.FullName},
                    { nameof(SmallProfileDto.City), r => r.City},
                };

                var selectedColumn = columnsSelectors[profileQuery.SortBy];
                mappedDtos = _paginationService
                    .SortRecords<SmallProfileDto>(selectedColumn, profileQuery.SortDirection, mappedDtos);
            }

            var profileDtos = _paginationService
                .ReturnRecordsToShow(profileQuery.PageNumber, profileQuery.PageSize, mappedDtos);

            foreach (var dto in profileDtos)
            {
                dto.Likes = await _likeRepository.CountLikesByProfil(dto.Id);
            }

            var result = new PagedResult<SmallProfileDto>(profileDtos, mappedDtos.Count(),profileQuery.PageSize, profileQuery.PageNumber);          
            return result;
        }

        public async Task<int> UpdateProfile(ProfileDto profileDto, int profileId)
        {         
            var profile = await GetProfileIfExist(profileId);
            var user = await _userContextService.GetUser();
            await _resourceOperationService.ResourceAuthorizationException
                (user, profile, new ResourceOperationRequirement(ResourceOperation.Update));

            var updatedProfile = _mapper.Map<Domain.Entities.Profile>(profileDto);
            updatedProfile.Id = profileId;
            updatedProfile.UserRef = profile.UserRef;
            var resultId = await _profileRepository.UpdateProfile(updatedProfile);

            return resultId;
        }

        public async Task<int> UpdateProfileDescription(string description, int profileId)
        {
            var profile = await GetProfileIfExist(profileId);

            var user = await _userContextService.GetUser();
            await _resourceOperationService.ResourceAuthorizationException
                (user, profile, new ResourceOperationRequirement(ResourceOperation.Update));

            var id  = await _profileRepository
                .UpdateProfileDescription(description, profileId);
            return id;
        }

        public async Task DeleteProfile(int profileId)
        {           
            var userId = await _userContextService.GetUserId();
            _logger.LogInformation($"Profile with id: {profileId} DELETE action invoked by user with id: {userId}");
            var user = await _userContextService.GetUser();

            var result = await _profileRepository.IsUserHaveProfile(userId);
            if (!result)
                throw new NotFoundException("User does not have Profile");

            var profile = await GetProfileIfExist(profileId);

            await _resourceOperationService.ResourceAuthorizationException
                (user, profile, new ResourceOperationRequirement(ResourceOperation.Delete));
            await _profileRepository.DeleteProfile(profileId);
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
