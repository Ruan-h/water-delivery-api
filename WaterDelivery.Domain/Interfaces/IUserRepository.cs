using WaterDelivery.Domain.Entities;

namespace WaterDelivery.Domain.Interfaces;

public interface IUserRepository
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetByEmailAsync(string email);
}