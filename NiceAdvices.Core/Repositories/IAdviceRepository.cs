using NiceAdvices.Core.Entities;

namespace NiceAdvices.Core.Repositories;

public interface IAdviceRepository
{
    public Task<List<Advice>> Get();
    
    public Task<Advice?> GetById(int id);
    
    public Task<Advice?> GetByCode(string code);
    
    public Task<Advice> Create(Advice advice);

    public Task Delete(Advice advice);
}