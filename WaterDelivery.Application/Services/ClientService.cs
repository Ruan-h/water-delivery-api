using FluentValidation;
using WaterDelivery.Application.DTOs;
using WaterDelivery.Application.Interfaces;
using WaterDelivery.Domain.Entities;
using WaterDelivery.Domain.Interfaces;

namespace WaterDelivery.Application.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IValidator<ClientRequest> _validator;

    public ClientService(IClientRepository clientRepository, IValidator<ClientRequest> validator)
    {
        _clientRepository = clientRepository;
        _validator = validator;
    }


    public async Task<ClientResponse?> GetByIdAsync(int id)
    {
        var client = await _clientRepository.GetByIdAsync(id);
        if (client == null) return null;
        return new ClientResponse(client.Id, client.UserId, client.Name, client.Phone);
    }

    public async Task<ClientResponse?> GetByUserIdAsync(int userId)
    {
        var client = await _clientRepository.GetByUserIdAsync(userId);
        if (client == null) return null;
        return new ClientResponse(client.Id, client.UserId, client.Name, client.Phone);
    }
}