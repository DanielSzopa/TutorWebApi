using AutoMapper;
using TutorWebApi.Domain;

namespace TutorWebApi.Application
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IUserContextService _userContextService;
        private readonly IMapper _mapper;

        public ProfileService(IProfileRepository profileRepository, IUserContextService userContextService ,IMapper mapper)
        {
            _profileRepository = profileRepository;
            _userContextService = userContextService;
            _mapper = mapper;
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
    }
}
