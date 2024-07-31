using Microsoft.EntityFrameworkCore;

namespace HumanResourceDictionary.Infrastructure.UnitOfWork;

public partial class HumanResourceDbContext : DbContext
{
    public HumanResourceDbContext()
    {
    }

    public HumanResourceDbContext(DbContextOptions<HumanResourceDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}