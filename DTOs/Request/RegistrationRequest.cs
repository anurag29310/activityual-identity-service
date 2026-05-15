namespace IdentityService.DTOs.Request
{
    public class RegistrationRequest
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
