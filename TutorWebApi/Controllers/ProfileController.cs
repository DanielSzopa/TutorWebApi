using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.Profile;

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
        public async Task<ActionResult> CreateProfile([FromBody]ProfileDto profileDto)
        {
            var profileId = await _profileService.CreateProfile(profileDto);
            return Created($"/api/v1/profile/{profileId}", null);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult>GetProfileById([FromRoute]int id)
        {
            var profile = await _profileService.GetProfile(id);
            return Ok(profile);
        }
        [HttpGet]
        public async Task<ActionResult> GetAllProfiles([FromQuery]string? searchPhrase)
        {
            var profiles = await _profileService.GetAllSmallProfiles(searchPhrase);
            return Ok(profiles);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProfile([FromBody]ProfileDto profileDto, [FromRoute]int id)
        {
            var profileId = await _profileService.UpdateProfile(profileDto, id);
            return Ok($"Profil with id: {profileId} was updated");
        }

        [HttpPut("{id}/description")]
        public async Task<ActionResult> UpdateProfileDescription([FromBody]string description, [FromRoute]int id)
        {
            var profileId = await _profileService.UpdateProfileDescription(description, id);
            return Ok($"Profil description with id: {profileId} was updated");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProfile([FromRoute]int id)
        {
            await _profileService.DeleteProfile(id);
            return NoContent();
        }     
    }
}
