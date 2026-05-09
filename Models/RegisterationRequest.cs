namespace IdentityService.Models
{
    public class RegisterationRequest
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
