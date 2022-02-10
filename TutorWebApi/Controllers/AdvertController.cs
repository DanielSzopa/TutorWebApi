using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.Advert;

namespace TutorWebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class AdvertController : Controller
    {
        private readonly IAdvertService _advertService;

        public AdvertController(IAdvertService advertService)
        {
            _advertService = advertService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAdvert([FromBody]NewAdvertDto advertDto)
        {
            var advertId = await _advertService.CreateAdvert(advertDto);
            return Created($"api/v1/advert/{advertId}", null);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAdverts([FromBody]AdvertQuery advertQuery)
        {
            var adverts = await _advertService.GetAllAdverts(advertQuery);
            return Ok(adverts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAdvert(int id)
        {
            var advert = await _advertService.GetAdvertById(id);
            return Ok(advert);
        }
    }
}
