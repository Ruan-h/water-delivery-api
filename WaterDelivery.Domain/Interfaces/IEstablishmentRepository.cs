using WaterDelivery.Domain.Entities;

namespace WaterDelivery.Domain.Interfaces
{
    public interface IEstablishmentRepository
    {
        Task<Establishment?> GetByIdAsync(int id);
        Task<Establishment> UpdateAsync(Establishment establishment);
    }
}