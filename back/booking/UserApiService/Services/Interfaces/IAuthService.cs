using UserApiService.View;

namespace UserApiService.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task<RegisterResponse> RegisterAsync(RegisterRequest request);
        Task<bool> DeleteUserAsync(int id);
        Task<bool> ExistsEntityAsync(int id);
    }
}
