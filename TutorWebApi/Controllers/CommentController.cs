using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutorWebApi.Application;

namespace TutorWebApi.Controllers
{
    [Route("/api/v1/profile/{id}/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateComment([FromBody]NewCommentDto commentDto, int id)
        {
            var commentId = await _commentService.CreateComment(commentDto,id);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllComments(int id)
        {
            var comments = await _commentService.GetAllComments(id);
            return Ok(comments);
        }

        [HttpPut("{commentId}")]
        public async Task<ActionResult> UpdateComment([FromBody]NewCommentDto commentDto,[FromRoute]int commentId,int id)
        {
            await _commentService.UpdateComment(commentDto,commentId,id);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteComment()
        {
            return Ok();
        }
    }
}
