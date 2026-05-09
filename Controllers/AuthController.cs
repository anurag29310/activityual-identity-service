using IdentityService.BusinessLogic.Interface;
using IdentityService.Data;
using IdentityService.Models;
using IdentityService.Models.Response;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IdentityDbContext _context;
    private readonly IJwtService _IJwtService;

    public AuthController(IdentityDbContext context, IJwtService jwt)
    {
        _context = context;
        _IJwtService = jwt;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterationRequest request)
    {
        var isUserRegistered = await _IJwtService.RegisterUserAsync(request);
        if (isUserRegistered)
            return Ok("User registered");
        else return BadRequest();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginRequest request)
    {
        var token = await _IJwtService.GenerateTokenAsync(request);

        return Ok(new AuthResponse { Token = token });
    }
}