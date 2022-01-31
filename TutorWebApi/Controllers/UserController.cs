using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.User;

namespace TutorWebApi.Controllers
{
    [Route("/api/v1/[controller]/{id}")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPut("address")]
        public async Task<ActionResult> UpdateAddress([FromBody] AddressDto addressDto, [FromRoute] int id)
        {
            await _userService.UpdateAddress(addressDto, id);
            return Ok();
        }

        [HttpPut("personal")]
        public async Task<ActionResult> UpdatePersonal([FromBody] PersonalDto personalDto, [FromRoute] int id)
        {
            await _userService.UpdatePersonal(personalDto, id);
            return Ok();
        }

    }
}
