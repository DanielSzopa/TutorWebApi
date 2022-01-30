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

        public async Task<int> CreateComment(NewCommentDto commentDto, int profileId)
        {
            var profile = await GetProfileIfExist(profileId);

            var userId = (int)await _userContextService.GetUserId();
            var comment = _mapper.Map<Comment>(commentDto);
            comment.UserId = userId;
            comment.ProfileId = profileId;

            var commentId = await _commentRepository.CreateComment(comment);
            return commentId;
        }

        public async Task<IEnumerable<CommentDto>> GetAllComments(int profileId)
        {
            var profile = await GetProfileIfExist(profileId);
            var comments = await _commentRepository.GetAllActiveComments(profileId);
            var commentDtos = _mapper.Map<List<CommentDto>>(comments);
            return commentDtos;
        }

        public async Task<CommentDto> GetCommentById(int profileId, int commentId)
        {
            var profile = await GetProfileIfExist(profileId);
            var comment = await GetCommentIfExist(commentId);
            var commentDto = _mapper.Map<CommentDto>(comment);
            return commentDto;
        }

        public async Task UpdateComment(NewCommentDto commentDto, int commentId, int profileId)
        {
            var profile = await GetProfileIfExist(profileId);
            var comment = await GetCommentIfExist(commentId);
            var user = await _userContextService.GetUser();

            await _resourceOperationService.ResourceAuthorizationException
                (user, comment, new ResourceOperationRequirement(ResourceOperation.Update));

            var mappedComment = _mapper.Map<Comment>(commentDto);
            mappedComment.Id = commentId;

            await _commentRepository.UpdateComment(mappedComment);
        }

        public async Task DeleteComment(int profileId, int commentId)
        {
            var profile = await GetProfileIfExist(profileId);
            var comment = await GetCommentIfExist(commentId);
            var user = await _userContextService.GetUser();
            await _resourceOperationService.ResourceAuthorizationException
                (user, comment, new ResourceOperationRequirement(ResourceOperation.Delete));
            await _commentRepository.DeleteComment(commentId);
        }

        public async Task<Comment> GetCommentIfExist(int commentId)
        {
            var comment = await _commentRepository.GetCommentById(commentId);
            if (comment is null || comment.IsActive == false)
                throw new NotFoundException("Comment not found");

            return comment;
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
