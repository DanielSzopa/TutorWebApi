using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TutorWebApi.Controllers
{
    [Route("/api/vi/[controller]/{id}/address")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        [HttpPut]
       public async Task<ActionResult> UpdateAddress()
        {
            return Ok();
        }
    }
}
