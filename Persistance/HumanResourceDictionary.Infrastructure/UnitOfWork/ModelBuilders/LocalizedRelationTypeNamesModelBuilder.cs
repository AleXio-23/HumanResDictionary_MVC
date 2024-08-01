using HumanResourceDictionary.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResourceDictionary.Infrastructure.UnitOfWork.ModelBuilders;

public class LocalizedRelationTypeNamesModelBuilder : IEntityTypeConfiguration<LocalizedRelationTypeNames>
{
    public void Configure(EntityTypeBuilder<LocalizedRelationTypeNames> entity)
    {
        entity.ToTable("LocalizedRelationTypeNames", "dictionary");
        entity.HasKey(x => x.Id);
        entity.Property(x => x.LanguageCode).HasColumnType("NVARCHAR(10)");
        entity.Property(x => x.Name).HasColumnType("NVARCHAR(100)");

        entity.HasOne(x => x.RelationType)
            .WithMany(x => x.LocalizedRelationTypeNames)
            .HasForeignKey(x => x.RelationTypeId);
    }
}