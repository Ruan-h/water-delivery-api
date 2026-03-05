using WaterDelivery.Application.DTOs;

namespace WaterDelivery.Application.Interfaces;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginRequest request);
    Task<UserResponse> RegisterAsync(RegisterRequest request);
}