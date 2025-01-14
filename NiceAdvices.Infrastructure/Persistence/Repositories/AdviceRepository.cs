using Microsoft.EntityFrameworkCore;
using NiceAdvices.Core.Entities;
using NiceAdvices.Core.Repositories;
using NiceAdvices.Infrastructure.Persistence.Context;

namespace NiceAdvices.Infrastructure.Persistence.Repositories;

public class AdviceRepository : IAdviceRepository
{
    private readonly NiceAdvicesDatabaseContext _context;

    public AdviceRepository(NiceAdvicesDatabaseContext context)
    {
        _context = context;
    }

    public async Task<List<Advice>> Get()
    {
        return await _context.Advices.ToListAsync();
    }

    public async Task<Advice?> GetById(int id)
    {
        var advice = await _context.Advices.FindAsync(id);
        return advice;
    }

    public  async Task<Advice?> GetByCode(string code)
    {
        var advice = await _context.Advices.FirstOrDefaultAsync(advice => advice.Code == code);
        return advice;
    }

    public async Task<Advice> Create(Advice advice)
    {
        var entity = _context.Advices.Add(advice);
        await _context.SaveChangesAsync();
        return entity.Entity;
    }

    public async Task Delete(Advice advice)
    {
        _context.Advices.Remove(advice);
        await _context.SaveChangesAsync();
    }
}