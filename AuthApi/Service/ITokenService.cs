using AuthApi.DTO;
using AuthApi.Models;

namespace AuthApi.Service
{
    public interface ITokenService
    {
        Task<AuthResponse> GenerateTokens(ApplicationUser user);
    }
}
