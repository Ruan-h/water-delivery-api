using FluentValidation;
using WaterDelivery.Application.DTOs;
using WaterDelivery.Application.Interfaces;
using WaterDelivery.Domain.Interfaces;

namespace WaterDelivery.Application.Services;

public class EstablishmentService : IEstablishmentService
{
    private readonly IEstablishmentRepository _repository;
    private readonly IValidator<EstablishmentRequest> _validator;
    private const int DefaultId = 1;

    public EstablishmentService(IEstablishmentRepository repository, IValidator<EstablishmentRequest> validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<EstablishmentResponse?> GetAsync()
    {
        var establishment = await _repository.GetByIdAsync(DefaultId);
        if (establishment == null) return null;

        return new EstablishmentResponse(establishment.Id, establishment.Name, establishment.IsOpen);
    }

    public async Task<EstablishmentResponse> UpdateNameAsync(EstablishmentRequest request)
    {
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        var establishment = await _repository.GetByIdAsync(DefaultId);
        if (establishment == null) throw new ArgumentException("Estabelecimento não encontrado.");

        establishment.UpdateName(request.Name);
        await _repository.UpdateAsync(establishment);

        return new EstablishmentResponse(establishment.Id, establishment.Name, establishment.IsOpen);
    }

    public async Task<EstablishmentResponse> OpenAsync()
    {
        var establishment = await _repository.GetByIdAsync(DefaultId);
        if (establishment == null) throw new ArgumentException("Estabelecimento não encontrado.");

        establishment.Open();
        await _repository.UpdateAsync(establishment);

        return new EstablishmentResponse(establishment.Id, establishment.Name, establishment.IsOpen);
    }

    public async Task<EstablishmentResponse> CloseAsync()
    {
        var establishment = await _repository.GetByIdAsync(DefaultId);
        if (establishment == null) throw new ArgumentException("Estabelecimento não encontrado.");

        establishment.Close();
        await _repository.UpdateAsync(establishment);

        return new EstablishmentResponse(establishment.Id, establishment.Name, establishment.IsOpen);
    }
}