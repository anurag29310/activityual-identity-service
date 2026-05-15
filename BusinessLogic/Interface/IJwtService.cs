using IdentityService.DTOs.Request;

namespace IdentityService.BusinessLogic.Interface
{
    public interface IJwtService
    {
        Task<string> GenerateTokenAsync(UserLoginRequest request);

        Task<bool> RegisterUserAsync(RegistrationRequest request);
    }
}
