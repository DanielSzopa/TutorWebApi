using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutorWebApi.Application;

namespace TutorWebApi.Controllers
{
    [Route("/api/v1/[controller]")]
    [ApiController]    
    [Authorize]
    public class ProfilController : ControllerBase
    {
        private readonly IProfilService _profilService;
        public ProfilController(IProfilService profilService)
        {
            _profilService = profilService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody]ProfilDto profilDto)
        {
            return Ok();
        }
    }
}
