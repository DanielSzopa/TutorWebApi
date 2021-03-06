using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.Comment;
using TutorWebApi.Application.Models.Page;

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
        public async Task<ActionResult> Create([FromBody] NewCommentDto commentDto, int id)
        {
            var commentId = await _commentService.CreateComment(commentDto, id);
            return Created($"/api/v1/profile/{id}/comment/{commentId}", null);
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<CommentDto>>> Get([FromQuery]CommentQuery commentQuery, int id)
        {
            var comments = await _commentService.GetAllComments(commentQuery, id);
            return Ok(comments);
        }

        [HttpGet("{commentId}")]
        public async Task<ActionResult<CommentDto>> Get([FromRoute] int commentId, int id)
        {
            var comment = await _commentService.GetCommentById(id, commentId);
            return Ok(comment);
        }

        [HttpPut("{commentId}")]
        public async Task<ActionResult> Update([FromBody] NewCommentDto commentDto, [FromRoute] int commentId, int id)
        {
            await _commentService.UpdateComment(commentDto, commentId, id);
            return Ok();
        }

        [HttpDelete("{commentId}")]
        public async Task<ActionResult> Delete([FromRoute]int commentId, int id)
        {
            await _commentService.DeleteComment(id, commentId);
            return NoContent();
        }
    }
}
