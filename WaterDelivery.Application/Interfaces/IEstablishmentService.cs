using WaterDelivery.Application.DTOs;

namespace WaterDelivery.Application.Interfaces;

public interface IEstablishmentService
{
    Task<EstablishmentResponse?> GetAsync();
    Task<EstablishmentResponse> UpdateNameAsync(EstablishmentRequest request);
    Task<EstablishmentResponse> OpenAsync();
    Task<EstablishmentResponse> CloseAsync();
}