using HumanResourceDictionary.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResourceDictionary.Infrastructure.UnitOfWork.ModelBuilders;

public class PhoneNumberDictionaryModelBuilder : IEntityTypeConfiguration<PhoneNumberDictionary>
{
    public void Configure(EntityTypeBuilder<PhoneNumberDictionary> entity)
    {
        entity.ToTable(" PhoneNumberDictionary", "ums");
        entity.HasKey(x => x.Id);
        entity.Property(x => x.PhoneNumber).HasColumnType("NVARCHAR(50)");

        entity.HasOne(x => x.PhoneNumberType)
            .WithMany(x => x.PhoneNumberDictionaries)
            .HasForeignKey(x => x.NumberTypeId);

        entity.HasOne(x => x.User)
            .WithMany(x => x.PhoneNumberDictionary)
            .HasForeignKey(x => x.NumberTypeId);
    }
}