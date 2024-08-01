using HumanResourceDictionary.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumanResourceDictionary.Infrastructure.UnitOfWork.ModelBuilders.DataSeeders;

public class GenderSeedData
{
    public Gender Gender { get; set; }
    public List<LocalizedGenderNames> LocalizedNames { get; set; }
}

public static class GenderDataSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var genderSeedData = new List<GenderSeedData>
        {
            new GenderSeedData
            {
                Gender = new Gender { Id = 1, Code = "FE" },
                LocalizedNames =
                [
                    new LocalizedGenderNames { Id = 1, GenderId = 1, LanguageCode = "GE", Name = "ქალი" },
                    new LocalizedGenderNames { Id = 2, GenderId = 1, LanguageCode = "EN", Name = "Female" }
                ]
            },
            new GenderSeedData
            {
                Gender = new Gender { Id = 2, Code = "MA" },
                LocalizedNames =
                [
                    new LocalizedGenderNames { Id = 3, GenderId = 2, LanguageCode = "GE", Name = "კაცი" },
                    new LocalizedGenderNames { Id = 4, GenderId = 2, LanguageCode = "EN", Name = "Male" }
                ]
            }
        };

        modelBuilder.Entity<Gender>().HasData(genderSeedData.Select(x => x.Gender).ToArray());
        modelBuilder.Entity<LocalizedGenderNames>().HasData(genderSeedData.SelectMany(x => x.LocalizedNames).ToArray());
    }
}