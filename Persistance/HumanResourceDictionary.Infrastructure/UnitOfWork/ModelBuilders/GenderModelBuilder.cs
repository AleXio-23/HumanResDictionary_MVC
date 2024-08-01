using HumanResourceDictionary.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResourceDictionary.Infrastructure.UnitOfWork.ModelBuilders;

public class GenderModelBuilder: IEntityTypeConfiguration<Gender>
{
    public void Configure(EntityTypeBuilder<Gender> entity)
    {
        entity.ToTable("Genders", "dictionary");
        entity.HasKey(x => x.Id);
        entity.Property(x => x.Code).HasColumnType("NVARCHAR(100)"); 
    }
}