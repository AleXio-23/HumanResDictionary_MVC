using HumanResourceDictionary.Infrastructure.Entities;
using HumanResourceDictionary.Infrastructure.UnitOfWork.ModelBuilders;
using HumanResourceDictionary.Infrastructure.UnitOfWork.ModelBuilders.DataSeeders;
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

    public virtual DbSet<City> Cities { get; set; } = null!;
    public virtual DbSet<LocalizedCityName> LocalizedCityNames { get; set; } = null!;
    public virtual DbSet<Gender> Genders { get; set; } = null!;
    public virtual DbSet<LocalizedGenderNames> LocalizedGenderNames { get; set; } = null!;
    public virtual DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CityModelBuilder());
        modelBuilder.ApplyConfiguration(new LocalizedCityNameModelBuilder());
        modelBuilder.ApplyConfiguration(new GenderModelBuilder());
        modelBuilder.ApplyConfiguration(new LocalizedGenderNamesModelBuilder());
        modelBuilder.ApplyConfiguration(new UserModelBuilder());


        CitiesDataSeeder.Seed(modelBuilder);
        GenderDataSeeder.Seed(modelBuilder);


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}