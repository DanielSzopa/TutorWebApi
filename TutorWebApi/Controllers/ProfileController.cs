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
        private readonly IProfileService _profilService;
        public ProfileController(IProfileService profilService)
        {
            _profilService = profilService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody]ProfileDto profileDto)
        {
            var profileId = await _profilService.CreateProfile(profileDto);
            return Created($"/api/v1/profile/{profileId}", null);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
            await _profilService.DeleteProfile(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody]ProfileDto profileDto,[FromRoute]int id)
        {
            var profileId = await _profilService.UpdateProfile(profileDto, id);
            return Ok($"Profil with id: {profileId} was updated");
        }
    }
}
