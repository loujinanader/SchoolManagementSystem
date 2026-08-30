using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using School.Api.Data;
using School.Api.DTO.authentication;
using School.Api.Models.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;

namespace School.Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly SchoolDbContext _db;
        private readonly IConfiguration _configuration;
        private readonly IPasswordHasher<User> _passwordHasher;
        public AuthController(SchoolDbContext db, IConfiguration configuration, IPasswordHasher<User> passwordHasher)
        {
            _db = db;
            _configuration = configuration;
            _passwordHasher = passwordHasher;
        }
        
        
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (dto == null) return BadRequest();
            var userName = dto.UserName?.Trim();
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(dto.Password))
                return BadRequest("Username and password are required.");

            if (await _db.Users.AnyAsync(u => u.UserName == userName))
                return Conflict("Username already exists.");

            var isFirstUser = !await _db.Users.AnyAsync();
            var user = new User
            {
                UserName = userName,
                Role = isFirstUser ? "Admin" : "User"
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Register), new { user.Id, user.UserName, user.Role });
        }

        [EnableRateLimiting("login")]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (dto == null) return BadRequest();
            var userName = dto.UserName?.Trim();
            var user = await _db.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            if (user == null)
                return Unauthorized("Invalid username or password.");
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
                return Unauthorized("Invalid username or password.");
            var token = GenerateToken(user);
            return Ok(new { token });
        }
        private string GenerateToken(User user)
        {
            var key = _configuration["Jwt:Key"];
            if (string.IsNullOrEmpty(key))
                throw new InvalidOperationException("JWT key is not configured.");
            var claims = new[]
            {
                new Claim( ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
               issuer: _configuration["Jwt:Issuer"],
               claims: claims,
               expires: DateTime.UtcNow.AddHours(1),
               signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}