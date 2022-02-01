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
        public async Task<ActionResult> CreateAchievement([FromBody]AchievementDto achievementDto, int id)
        {
            await _achievementService.CreateAchievement(achievementDto, id);
            return Ok();
        }

        [HttpPut("{achievement-id}")]
        public async Task<ActionResult> UpdateAchievement([FromBody] AchievementDto achievementDto, [FromRoute]int achievementId, int id)
        {
            return Ok();
        }

        [HttpDelete("{achievement-id}")]
        public async Task<ActionResult> DeleteAchievement([FromRoute] int achievementId, int id)
        {
            return NoContent();
        }

    }
}
