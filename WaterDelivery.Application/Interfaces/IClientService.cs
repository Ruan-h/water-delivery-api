using WaterDelivery.Application.DTOs;

namespace WaterDelivery.Application.Interfaces;

public interface IClientService
{
    Task<ClientResponse?> GetByIdAsync(int id);
    Task<ClientResponse?> GetByUserIdAsync(int userId);
}