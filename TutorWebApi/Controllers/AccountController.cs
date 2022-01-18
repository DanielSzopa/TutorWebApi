using Microsoft.AspNetCore.Mvc;
using TutorWebApi.Application;

namespace TutorWebApi.Controllers
{
    [Route("/api/v1/account")]
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
            await _accountService.RegisterUser(registerDto);
            return Ok();
        }
    }
}
