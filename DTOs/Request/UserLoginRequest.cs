namespace IdentityService.DTOs.Request
{
    public class UserLoginRequest
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
