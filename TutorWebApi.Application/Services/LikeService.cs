using AutoMapper;
using TutorWebApi.Application.Authorization;
using TutorWebApi.Application.Exceptions;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.Like;
using TutorWebApi.Domain.Entities;
using TutorWebApi.Domain.Interfaces;

namespace TutorWebApi.Application.Services
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IUserContextService _userContextService;
        private readonly IMapper _mapper;
        private readonly IProfileRepository _profileRepository;
        private readonly IResourceOperationService<Like> _resourceOperationService;

        public LikeService(ILikeRepository likeRepository,
            IUserContextService userContextService, IMapper mapper, IProfileRepository profileRepository,
            IResourceOperationService<Like> resourceOperationService)
        {
            _likeRepository = likeRepository;
            _userContextService = userContextService;
            _mapper = mapper;
            _profileRepository = profileRepository;
            _resourceOperationService = resourceOperationService;
        }

        public async Task Like(int profileId)
        {
            var profile = await GetProfileIfExist(profileId);
            var userId = await _userContextService.GetUserId();

            var like = await _likeRepository.GetLike(profile.Id, userId);
            if (like != null)
            {
                if (like.IsActive == true)
                {
                    throw new BadRequestException("User can not like this profile again");
                }
                else
                {
                    await _likeRepository.UpdateLike(like);
                    return;
                }
            }

            var newLike = new Like { ProfileId = profileId, UserId = userId };
            await _likeRepository.CreateLike(newLike);
        }


        public async Task Unlike(int profileId)
        {
            var profile = await GetProfileIfExist(profileId);
            var userId = await _userContextService.GetUserId();
            var user = await _userContextService.GetUser();
            var like = await _likeRepository.GetLike(profileId, userId);
            if(like != null)
            {
                await _resourceOperationService.ResourceAuthorizationException
                (user, like, new ResourceOperationRequirement(ResourceOperation.Delete));
                await _likeRepository.DeleteLike(like);
            }            
        }

        public async Task<IEnumerable<LikeDto>> GetAllLikes(int profileId)
        {
            var profile = await GetProfileIfExist(profileId);
            var likes = await _likeRepository.GetAllActiveLikes(profileId);
            var likeDtos = _mapper.Map<IEnumerable<LikeDto>>(likes);
            return likeDtos;
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
