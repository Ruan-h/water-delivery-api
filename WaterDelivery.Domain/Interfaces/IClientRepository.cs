using WaterDelivery.Domain.Entities;

namespace WaterDelivery.Domain.Interfaces;

public interface IClientRepository
{
    Task<Client> CreateAsync(Client client);
    Task<Client?> GetByIdAsync(int id);
    Task<Client?> GetByUserIdAsync(int userId);
}