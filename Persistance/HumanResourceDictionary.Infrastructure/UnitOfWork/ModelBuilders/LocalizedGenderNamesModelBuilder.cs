using HumanResourceDictionary.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResourceDictionary.Infrastructure.UnitOfWork.ModelBuilders;

public class LocalizedGenderNamesModelBuilder : IEntityTypeConfiguration<LocalizedGenderNames>
{
    public void Configure(EntityTypeBuilder<LocalizedGenderNames> entity)
    {
        entity.ToTable("LocalizedGenderNames", "dictionary");
        entity.HasKey(x => x.Id);
        entity.Property(x => x.LanguageCode).HasColumnType("NVARCHAR(10)");
        entity.Property(x => x.Name).HasColumnType("NVARCHAR(100)");

        entity.HasOne(x => x.Gender)
            .WithMany(x => x.LocalizedGenderNames)
            .HasForeignKey(x => x.GenderId);
    }
}