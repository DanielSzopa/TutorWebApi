using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.Profile;

namespace TutorWebApi.Controllers
{
    [Route("/api/v1/profile/{id}/[controller]")]
    [ApiController]
    [Authorize]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService _experienceService;

        public ExperienceController(IExperienceService experienceService )
        {
            _experienceService = experienceService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateExperience([FromBody] ExperienceDto experienceDto, int id)
        {
            await _experienceService.CreateExperience(experienceDto, id);
            return Ok();
        }

        [HttpPut("{experienceId}")]
        public async Task<ActionResult> UpdateExperience([FromBody] ExperienceDto experienceDto, [FromRoute] int experienceId, int id)
        {
            await _experienceService.UpdateExperience(experienceDto, experienceId, id);
            return Ok();
        }

        [HttpDelete("{experienceId}")]
        public async Task<ActionResult> DeleteExperience([FromRoute] int experienceId, int id)
        {
            await _experienceService.DeleteExperience(experienceId, id);
            return NoContent();
        }
    }
}
