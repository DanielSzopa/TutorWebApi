using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutorWebApi.Application;

namespace TutorWebApi.Controllers
{
    [Route("/api/v1/[controller]/{id}/address")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        [HttpPut]
        public async Task<ActionResult> UpdateAddress([FromBody]AddressDto addressDto, [FromRoute]int id)
        {
            return Ok();
        }
    }
}
