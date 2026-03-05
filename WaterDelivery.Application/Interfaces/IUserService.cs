using WaterDelivery.Application.DTOs;

namespace WaterDelivery.Application.Interfaces;

public interface IUserService
{
    Task<UserResponse> CreateAsync(CreateUserRequest request);
    Task<UserResponse?> GetByIdAsync(int id);
    Task<UserResponse?> GetByEmailAsync(string email);
}