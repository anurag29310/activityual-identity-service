using IdentityService.Models;

namespace IdentityService.BusinessLogic.Interface
{
    public interface IJwtService
    {
        Task<string> GenerateTokenAsync(UserLoginRequest request);

        Task<bool> RegisterUserAsync(RegisterationRequest request);
    }
}
