using HumanResourceDictionary.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResourceDictionary.Infrastructure.UnitOfWork.ModelBuilders;

public class RelationTypesModelBuilder: IEntityTypeConfiguration<RelationTypes>
{
    public void Configure(EntityTypeBuilder<RelationTypes> entity)
    {
        entity.ToTable("RelationTypes", "dictionary");
        entity.HasKey(x => x.Id);
        entity.Property(x => x.Code).HasColumnType("NVARCHAR(100)"); 
    }
}