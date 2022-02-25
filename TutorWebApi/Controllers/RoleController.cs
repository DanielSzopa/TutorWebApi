using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.Role;

namespace TutorWebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _roleService.GetAllRoles();
            return Ok(roles);
        }

        [HttpPut]
        public async Task<ActionResult> ChangeRole([FromBody] ChangeRoleRequestDto request)
        {
            await _roleService.UpdateRole(request);
            return Ok();
        }
    }
}
