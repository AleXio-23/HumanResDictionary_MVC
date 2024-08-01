using HumanResourceDictionary.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResourceDictionary.Infrastructure.UnitOfWork.ModelBuilders;

public class PhoneNumberTypesModelBuilder: IEntityTypeConfiguration<PhoneNumberTypes>
{
    public void Configure(EntityTypeBuilder<PhoneNumberTypes> entity)
    {
        entity.ToTable("PhoneNumberTypes", "dictionary");
        entity.HasKey(x => x.Id);
        entity.Property(x => x.Code).HasColumnType("NVARCHAR(50)"); 
    }
}