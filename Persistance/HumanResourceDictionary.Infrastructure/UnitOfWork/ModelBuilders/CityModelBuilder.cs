using HumanResourceDictionary.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResourceDictionary.Infrastructure.UnitOfWork.ModelBuilders;

public class CityModelBuilder : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> entity)
    {
        entity.ToTable("Cities", "dictionary");
        entity.HasKey(x => x.Id);
        entity.Property(x => x.Code).HasColumnType("NVARCHAR(100)"); 
    }
}