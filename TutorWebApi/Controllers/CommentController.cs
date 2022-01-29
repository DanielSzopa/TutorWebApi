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

        [HttpPut]
        public async Task<ActionResult> UpdateComment()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteComment()
        {
            return Ok();
        }
    }
}
