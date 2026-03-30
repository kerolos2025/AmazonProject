using AuthApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager,
                              UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(string role)
        {
            await _roleManager.CreateAsync(new IdentityRole(role));
            return Ok();
        }

        [HttpPost("assign")]
        public async Task<IActionResult> Assign(string username, string role)
        {
            var user = await _userManager.FindByNameAsync(username);
            await _userManager.AddToRoleAsync(user, role);
            return Ok();
        }
    }
}
