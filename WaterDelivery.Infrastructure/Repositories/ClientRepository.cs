using Microsoft.EntityFrameworkCore;
using WaterDelivery.Domain.Entities;
using WaterDelivery.Domain.Interfaces;
using WaterDelivery.Infrastructure.Context;

namespace WaterDelivery.Infrastructure.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly ApplicationDbContext _context;

    public ClientRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Client> CreateAsync(Client client)
    {
        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task<Client?> GetByIdAsync(int id)
    {
        return await _context.Clients.FindAsync(id);
    }

    public async Task<Client?> GetByUserIdAsync(int userId)
    {
        return await _context.Clients.FirstOrDefaultAsync(c => c.UserId == userId);
    }
}