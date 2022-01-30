using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutorWebApi.Application;

namespace TutorWebApi.Controllers
{
    [Route("/api/v1/profile/{id}/[controller]")]
    [ApiController]
    [Authorize]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost]
        public async Task<ActionResult> Like(int id)
        {
            await _likeService.Like(id);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> UnLike(int id)
        {
            await _likeService.Unlike(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult> GetLikes()
        {
            return Ok();
        }
    }
}
