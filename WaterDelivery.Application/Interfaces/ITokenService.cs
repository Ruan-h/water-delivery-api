using WaterDelivery.Domain.Entities;

namespace WaterDelivery.Application.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}