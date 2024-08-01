using HumanResourceDictionary.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumanResourceDictionary.Infrastructure.UnitOfWork.ModelBuilders.DataSeeders;

public record RelationSeedData
{
    public RelationTypes RelationType { get; set; }
    public List<LocalizedRelationTypeNames> LocalizedRelationTypeNames { get; set; }
}

public static class RelationTypesDataSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var seedData = new List<RelationSeedData>
        {
            new()
            {
                RelationType = new RelationTypes() { Id = 1, Code = "COW" },
                LocalizedRelationTypeNames =
                [
                    new LocalizedRelationTypeNames
                        { Id = 1, RelationTypeId = 1, LanguageCode = "GE", Name = "თანამშრომელი" },
                    new LocalizedRelationTypeNames
                        { Id = 2, RelationTypeId = 1, LanguageCode = "EN", Name = "Co-Worker" }
                ]
            },
            new()
            {
                RelationType = new RelationTypes { Id = 2, Code = "FA" },
                LocalizedRelationTypeNames =
                [
                    new LocalizedRelationTypeNames
                        { Id = 3, RelationTypeId = 2, LanguageCode = "GE", Name = "ნაცნობი" },
                    new LocalizedRelationTypeNames
                        { Id = 4, RelationTypeId = 2, LanguageCode = "EN", Name = "Familiar" }
                ]
            },
            new()
            {
                RelationType = new RelationTypes { Id = 3, Code = "REL" },
                LocalizedRelationTypeNames =
                [
                    new LocalizedRelationTypeNames
                        { Id = 5, RelationTypeId = 3, LanguageCode = "GE", Name = "ნათესავი" },
                    new LocalizedRelationTypeNames
                        { Id = 6, RelationTypeId = 3, LanguageCode = "EN", Name = "Relative" }
                ]
            },
            new()
            {
                RelationType = new RelationTypes { Id = 4, Code = "OTH" },
                LocalizedRelationTypeNames =
                [
                    new LocalizedRelationTypeNames { Id = 7, RelationTypeId = 4, LanguageCode = "GE", Name = "სხვა" },
                    new LocalizedRelationTypeNames { Id = 8, RelationTypeId = 4, LanguageCode = "EN", Name = "Other" }
                ]
            }
        };
        
        modelBuilder.Entity<City>().HasData(seedData.Select(x => x.RelationType).ToArray());
        modelBuilder.Entity<LocalizedCityName>().HasData(seedData.SelectMany(x => x.LocalizedRelationTypeNames).ToArray());
    }
}