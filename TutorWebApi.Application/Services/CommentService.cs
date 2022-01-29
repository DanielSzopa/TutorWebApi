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
        private readonly IResourceOperationService<Comment> _resourceOperationService;

        public CommentService(ICommentRepository commentRepository, IProfileRepository profileRepository,
            IMapper mapper, IUserContextService userContextService, 
            IResourceOperationService<Comment> resourceOperationService)
        {
            _commentRepository = commentRepository;
            _profileRepository = profileRepository;
            _mapper = mapper;
            _userContextService = userContextService;
            _resourceOperationService = resourceOperationService;
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

        public async Task UpdateComment(CommentDto commentDto, int commentId, int profileId)
        {
            var profile = await _profileRepository.GetProfileById(profileId);
            if(profile is null || profile.IsActive == false)
                throw new NotFoundException("Profile not found");

            var comment = await _commentRepository.GetCommentById(commentId);
            if(comment is null || comment.IsActive == false)
                throw new NotFoundException("Comment not found");

            var user = await _userContextService.GetUser();

            await _resourceOperationService.ResourceAuthorizationException
                (user, comment, new ResourceOperationRequirement(ResourceOperation.Update));

            var mappedComment = _mapper.Map<Comment>(commentDto);
            mappedComment.Id = commentId;

            await _commentRepository.UpdateComment(mappedComment);
        }
    }
}
