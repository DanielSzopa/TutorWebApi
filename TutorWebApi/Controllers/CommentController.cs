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
        public async Task<ActionResult> CreateComment([FromBody]CommentDto commentDto, int id)
        {
            var commentId = await _commentService.CreateComment(commentDto,id);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetComments()
        {
            return Ok();
        }

        [HttpPut("{commentId}")]
        public async Task<ActionResult> UpdateComment([FromBody]CommentDto commentDto,[FromRoute]int commentId,int id)
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
