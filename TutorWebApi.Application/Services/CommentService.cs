using AutoMapper;
using TutorWebApi.Domain;

namespace TutorWebApi.Application
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IProfileRepository _profileRepository;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;

        public CommentService(ICommentRepository commentRepository, IProfileRepository profileRepository,
            IMapper mapper, IUserContextService userContextService)
        {
            _commentRepository = commentRepository;
            _profileRepository = profileRepository;
            _mapper = mapper;
            _userContextService = userContextService;
        }

        public async Task<int> CreateComment(CommentDto commentDto, int profileId)
        {
            var profile = await _profileRepository.GetProfileById(profileId);
            if (profile is null || profile.IsActive == false)
                throw new NotFoundException("Profile not found");

            var userId = (int)await _userContextService.GetUserId();
            var comment = _mapper.Map<Comment>(commentDto);
            comment.UserId = userId;
            comment.ProfileId = profileId;

            var commentId = await _commentRepository.CreateComment(comment);
            return commentId;
        }
    }
}
