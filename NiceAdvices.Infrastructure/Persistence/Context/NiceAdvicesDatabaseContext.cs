using Microsoft.EntityFrameworkCore;
using NiceAdvices.Core.Entities;

namespace NiceAdvices.Infrastructure.Persistence.Context;

public class NiceAdvicesDatabaseContext : DbContext
{
    public NiceAdvicesDatabaseContext(DbContextOptions<NiceAdvicesDatabaseContext> options) : base(options) {}
    
    public DbSet<Advice> Advices { get; set; }
}