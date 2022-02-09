using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutorWebApi.Application.Models.Advert;

namespace TutorWebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class AdvertController : Controller
    {
        public AdvertController()
        {

        }

        [HttpPost]
        public async Task<ActionResult> CreateAdvert([FromBody]NewAdvertDto advertDto)
        {
            return Ok();
        }
    }
}
