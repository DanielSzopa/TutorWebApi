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
        public async Task<ActionResult> Create([FromBody]ProfileDto profilDto)
        {
            var profilId = await _profilService.CreateProfile(profilDto);
            return Created($"/api/v1/profile/{profilId}", null);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete()
        {
            await _profilService.DeleteProfile();
            return NoContent();
        }
    }
}
