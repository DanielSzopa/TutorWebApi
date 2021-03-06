using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.Profile;

namespace TutorWebApi.Controllers
{
    [Route("/api/v1/profile/{id}/[controller]")]
    [ApiController]
    [Authorize]
    public class AchievementController : ControllerBase
    {
        private readonly IAchievementService _achievementService;

        public AchievementController(IAchievementService achievementService)
        {
            _achievementService = achievementService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody]AchievementDto achievementDto, int id)
        {
            await _achievementService.CreateAchievement(achievementDto, id);
            return Ok();
        }

        [HttpPut("{achievementId}")]
        public async Task<ActionResult> Update([FromBody] AchievementDto achievementDto, [FromRoute]int achievementId, int id)
        {
            await _achievementService.UpdateAchievement(achievementDto,achievementId,id);
            return Ok();
        }

        [HttpDelete("{achievementId}")]
        public async Task<ActionResult> Delete([FromRoute] int achievementId, int id)
        {
            await _achievementService.DeleteAchievement(achievementId,id);
            return NoContent();
        }
    }
}
