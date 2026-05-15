using IdentityService.BusinessLogic.Interface;
using IdentityService.Data;
using IdentityService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityService.BusinessLogic.Implementation
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;
        private readonly IdentityDbContext _context;

        public JwtService(IConfiguration config, IdentityDbContext context)
        {
            _config = config;
            _context = context;
        }

        public async Task<string> GenerateTokenAsync(UserLoginRequest request)
        {
            var user = await _context.Users
            .FirstOrDefaultAsync(x => x.Email == request.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {

            }
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]!);

            var claims = new[]
                {
                new Claim(ClaimTypes.NameIdentifier, user!.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
                 };

            var creds = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> RegisterUserAsync(RegisterationRequest request)
        {
            if (await _context.Users.AnyAsync(x => x.Email == request.Email))
                return false;

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
