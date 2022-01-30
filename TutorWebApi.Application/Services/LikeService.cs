using AutoMapper;
using TutorWebApi.Domain;

namespace TutorWebApi.Application
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IUserContextService _userContextService;
        private readonly IMapper _mapper;
        private readonly IProfileRepository _profileRepository;

        public LikeService(ILikeRepository likeRepository,
            IUserContextService userContextService, IMapper mapper, IProfileRepository profileRepository)
        {
            _likeRepository = likeRepository;
            _userContextService = userContextService;
            _mapper = mapper;
            _profileRepository = profileRepository;
        }

        public async Task Like(int profileId)
        {
            var profile = await GetProfileIfExist(profileId);
            var userId = (int)await _userContextService.GetUserId();

            var result = await _likeRepository.IsUserCanLikeThisProfile(profileId, userId);
            if (result == false)
                throw new BadRequestException("User can not like this profile again");

            var like = new Like { ProfileId = profileId, UserId = userId};
            await _likeRepository.CreateLike(like);
        }


        public async Task Unlike(int profileId)
        {
            var profile = await GetProfileIfExist(profileId);
            var userId = (int)await _userContextService.GetUserId();
            var like = new Like { ProfileId = profileId, UserId = userId };
            await _likeRepository.DeleteLike(like);
        }

        public async Task<Domain.Profile> GetProfileIfExist(int profileId)
        {
            var profile = await _profileRepository.GetProfileById(profileId);
            if (profile is null || profile.IsActive == false)
                throw new NotFoundException("Profile not found");

            return profile;
        }
    }
}
