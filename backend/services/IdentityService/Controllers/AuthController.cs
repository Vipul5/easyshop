using IdentityService.Data;
using IdentityService.DTOs;
using IdentityService.Models;
using IdentityService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IdentityDbContext _context;
        private readonly TokenService _tokenService;

        public AuthController(IdentityDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
              var exixtingUser = await _context.Users
                .FirstOrDefaultAsync(x => x.UserName == dto.UserName);

            if(exixtingUser != null)
            {
                return BadRequest("Already registered");
            }

            var user = new User
            {
                UserName = dto.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User registered");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.UserName == dto.UserName);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                return Unauthorized("Invalid credentials");

            var token = _tokenService.GenerateToken(user);

          return Ok(new
            {
                userId = user.Id,
                userName = user.UserName,
                token = token
            });
        }
    }
}