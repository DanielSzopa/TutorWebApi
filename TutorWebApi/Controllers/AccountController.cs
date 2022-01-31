using Microsoft.AspNetCore.Mvc;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.Account;

namespace TutorWebApi.Controllers
{
    [Route("/api/v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpPost("register")]
        public async Task<ActionResult> RegisterAccount([FromBody]RegisterDto registerDto)
        {
            await _accountService.RegisterUserAsync(registerDto);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody]LoginDto loginDto)
        {
            string token = await _accountService.AuthenticateUserAsync(loginDto);
            return Ok(token);
        }
    }
}
