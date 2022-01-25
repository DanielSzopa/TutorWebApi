using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutorWebApi.Application;

namespace TutorWebApi.Controllers
{
    [Route("/api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody]ProfileDto profileDto)
        {
            var profileId = await _profileService.CreateProfile(profileDto);
            return Created($"/api/v1/profile/{profileId}", null);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Read([FromRoute]int id)
        {
            var profile = await _profileService.GetProfile(id);
            return Ok(profile);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody]ProfileDto profileDto, [FromRoute]int id)
        {
            var profileId = await _profileService.UpdateProfile(profileDto, id);
            return Ok($"Profil with id: {profileId} was updated");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
            await _profileService.DeleteProfile(id);
            return NoContent();
        }     
    }
}
