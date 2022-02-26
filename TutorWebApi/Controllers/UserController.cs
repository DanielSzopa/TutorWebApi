using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.User;

namespace TutorWebApi.Controllers
{
    [Route("/api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers(UserQuery query)
        {
            var users = await _userService.GetAllUsers(query);
            return Ok(users);
        }

        [HttpPut("address/{id}")]
        public async Task<ActionResult> UpdateAddress([FromBody] AddressDto addressDto, [FromRoute] int id)
        {
            await _userService.UpdateAddress(addressDto, id);
            return Ok();
        }

        [HttpPut("personal/{id}")]
        public async Task<ActionResult> UpdatePersonal([FromBody] PersonalDto personalDto, [FromRoute] int id)
        {
            await _userService.UpdatePersonal(personalDto, id);
            return Ok();
        }

    }
}
