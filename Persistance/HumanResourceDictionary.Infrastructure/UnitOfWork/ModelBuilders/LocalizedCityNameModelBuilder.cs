using HumanResourceDictionary.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResourceDictionary.Infrastructure.UnitOfWork.ModelBuilders;

public class LocalizedCityNameModelBuilder : IEntityTypeConfiguration<LocalizedCityName>
{
    public void Configure(EntityTypeBuilder<LocalizedCityName> entity)
    {
        entity.ToTable("LocalizedCityNames", "dictionary");
        entity.HasKey(x => x.Id);
        entity.Property(x => x.LanguageCode).HasColumnType("NVARCHAR(10)");
        entity.Property(x => x.Name).HasColumnType("NVARCHAR(100)");

        entity.HasOne(x => x.City)
            .WithMany(x => x.LocalizedNames)
            .HasForeignKey(x => x.CityId);
    }
}