using AuthApi.Data;
using AuthApi.DTO;
using AuthApi.Models;
using AuthApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly AppDbContext _context;

        public AuthController(UserManager<ApplicationUser> userManager,
                              ITokenService tokenService,
                              AppDbContext context)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var user = new ApplicationUser { UserName = dto.Username,FullName=dto.FullName };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Username);

            if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password))
                return Unauthorized();

            var tokens = await _tokenService.GenerateTokens(user);

            return Ok(tokens);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(string refreshToken)
        {
            var token = await _context.RefreshTokens
                .FirstOrDefaultAsync(x => x.Token == refreshToken);

            if (token == null || token.IsRevoked || token.ExpiryDate < DateTime.UtcNow)
                return Unauthorized();

            token.IsRevoked = true;

            var user = await _userManager.FindByIdAsync(token.UserId);

            var newTokens = await _tokenService.GenerateTokens(user);

            await _context.SaveChangesAsync();

            return Ok(newTokens);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(string refreshToken)
        {
            var token = await _context.RefreshTokens
                .FirstOrDefaultAsync(x => x.Token == refreshToken);

            if (token != null)
            {
                token.IsRevoked = true;
                await _context.SaveChangesAsync();
            }

            return Ok();
        }
    }
}
