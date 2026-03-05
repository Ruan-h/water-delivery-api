using Microsoft.EntityFrameworkCore;
using WaterDelivery.Domain.Entities;
using WaterDelivery.Domain.Interfaces;
using WaterDelivery.Infrastructure.Context;

namespace WaterDelivery.Infrastructure.Repositories;

public class EstablishmentRepository : IEstablishmentRepository
{
    private readonly ApplicationDbContext _context;

    public EstablishmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Establishment?> GetByIdAsync(int id)
    {
        return await _context.Establishments.FindAsync(id);
    }

    public async Task<Establishment> UpdateAsync(Establishment establishment)
    {
        _context.Establishments.Update(establishment);
        await _context.SaveChangesAsync();
        return establishment;
    }
}