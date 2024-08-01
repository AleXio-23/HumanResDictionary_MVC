using HumanResourceDictionary.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResourceDictionary.Infrastructure.UnitOfWork.ModelBuilders;

public class LocalizedPhoneNumberTypeNamesModelBuilder : IEntityTypeConfiguration<LocalizedPhoneNumberTypeNames>
{
    public void Configure(EntityTypeBuilder<LocalizedPhoneNumberTypeNames> entity)
    {
        entity.ToTable("LocalizedPhoneNumberTypeNames", "dictionary");
        entity.HasKey(x => x.Id);
        entity.Property(x => x.LanguageCode).HasColumnType("NVARCHAR(10)");
        entity.Property(x => x.TypeName).HasColumnType("NVARCHAR(100)");

        entity.HasOne(x => x.PhoneNumberType)
            .WithMany(x => x.LocalizedPhoneNumberTypeNames)
            .HasForeignKey(x => x.PhoneNumberTypeId);
    }
}