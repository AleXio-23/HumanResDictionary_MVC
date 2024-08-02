using HumanResourceDictionary.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumanResourceDictionary.Infrastructure.UnitOfWork.ModelBuilders.DataSeeders;

public record PhoneNumberSeedData
{
    public PhoneNumberTypes PhoneNumberType { get; set; }
    public List<LocalizedPhoneNumberTypeNames> LocalizedPhoneNumberTypeNames { get; set; }
}

public static class PhoneNumberTypesDataSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var seedData = new List<PhoneNumberSeedData>
        {
            new()
            {
                PhoneNumberType = new PhoneNumberTypes() { Id = 1, Code = "MOB" },
                LocalizedPhoneNumberTypeNames =
                [
                    new LocalizedPhoneNumberTypeNames
                        { Id = 1, PhoneNumberTypeId = 1, LanguageCode = "GE", TypeName = "მობილური" },
                    new LocalizedPhoneNumberTypeNames
                        { Id = 2, PhoneNumberTypeId = 1, LanguageCode = "EN", TypeName = "Mobile" }
                ]
            },
            new()
            {
                PhoneNumberType = new PhoneNumberTypes { Id = 2, Code = "OFC" },
                LocalizedPhoneNumberTypeNames =
                [
                    new LocalizedPhoneNumberTypeNames
                        { Id = 3, PhoneNumberTypeId = 2, LanguageCode = "GE", TypeName = "ოფისი" },
                    new LocalizedPhoneNumberTypeNames
                        { Id = 4, PhoneNumberTypeId = 2, LanguageCode = "EN", TypeName = "Office" }
                ]
            },
            new()
            {
                PhoneNumberType = new PhoneNumberTypes { Id = 3, Code = "HOM" },
                LocalizedPhoneNumberTypeNames =
                [
                    new LocalizedPhoneNumberTypeNames
                        { Id = 5, PhoneNumberTypeId = 3, LanguageCode = "GE", TypeName = "სახლი" },
                    new LocalizedPhoneNumberTypeNames
                        { Id = 6, PhoneNumberTypeId = 3, LanguageCode = "EN", TypeName = "Home" }
                ]
            }
        };

        modelBuilder.Entity<PhoneNumberTypes>().HasData(seedData.Select(x => x.PhoneNumberType).ToArray());
        modelBuilder.Entity<LocalizedPhoneNumberTypeNames>()
            .HasData(seedData.SelectMany(x => x.LocalizedPhoneNumberTypeNames).ToArray());
    }
}