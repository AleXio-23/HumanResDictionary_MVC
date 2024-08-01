using HumanResourceDictionary.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumanResourceDictionary.Infrastructure.UnitOfWork.ModelBuilders.DataSeeders;

public record CitySeedData
{
    public City City { get; set; }
    public List<LocalizedCityName> LocalizedNames { get; set; }
}

public static class CitiesDataSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var citySeedData = new List<CitySeedData>
        {
            new()
            {
                City = new City { Id = 1, Code = "TBS" },
                LocalizedNames =
                [
                    new LocalizedCityName { Id = 1, CityId = 1, LanguageCode = "GE", Name = "თბილისი" },
                    new LocalizedCityName { Id = 2, CityId = 1, LanguageCode = "EN", Name = "Tbilisi" }
                ]
            },
            new()
            {
                City = new City { Id = 2, Code = "KUT" },
                LocalizedNames =
                [
                    new LocalizedCityName { Id = 3, CityId = 2, LanguageCode = "GE", Name = "ქუთაისი" },
                    new LocalizedCityName { Id = 4, CityId = 2, LanguageCode = "EN", Name = "Kutaisi" }
                ]
            },
            new()
            {
                City = new City { Id = 3, Code = "BAT" },
                LocalizedNames =
                [
                    new LocalizedCityName { Id = 5, CityId = 3, LanguageCode = "GE", Name = "ბათუმი" },
                    new LocalizedCityName { Id = 6, CityId = 3, LanguageCode = "EN", Name = "Batumi" }
                ]
            },
            new()
            {
                City = new City { Id = 4, Code = "RUS" },
                LocalizedNames =
                [
                    new LocalizedCityName { Id = 7, CityId = 4, LanguageCode = "GE", Name = "რუსთავი" },
                    new LocalizedCityName { Id = 8, CityId = 4, LanguageCode = "EN", Name = "Rustavi" }
                ]
            },
            new()
            {
                City = new City { Id = 5, Code = "ZUG" },
                LocalizedNames =
                [
                    new LocalizedCityName { Id = 9, CityId = 5, LanguageCode = "GE", Name = "ზუგდიდი" },
                    new LocalizedCityName { Id = 10, CityId = 5, LanguageCode = "EN", Name = "Zugdidi" }
                ]
            },
            new()
            {
                City = new City { Id = 6, Code = "GOR" },
                LocalizedNames =
                [
                    new LocalizedCityName { Id = 11, CityId = 6, LanguageCode = "GE", Name = "გორი" },
                    new LocalizedCityName { Id = 12, CityId = 6, LanguageCode = "EN", Name = "Gori" }
                ]
            },
            new()
            {
                City = new City { Id = 7, Code = "TEL" },
                LocalizedNames =
                [
                    new LocalizedCityName { Id = 13, CityId = 7, LanguageCode = "GE", Name = "თელავი" },
                    new LocalizedCityName { Id = 14, CityId = 7, LanguageCode = "EN", Name = "Telavi" }
                ]
            },
            new()
            {
                City = new City { Id = 8, Code = "POT" },
                LocalizedNames =
                [
                    new LocalizedCityName { Id = 15, CityId = 8, LanguageCode = "GE", Name = "ფოთი" },
                    new LocalizedCityName { Id = 16, CityId = 8, LanguageCode = "EN", Name = "Poti" }
                ]
            },
            new()
            {
                City = new City { Id = 9, Code = "OZA" },
                LocalizedNames =
                [
                    new LocalizedCityName { Id = 17, CityId = 9, LanguageCode = "GE", Name = "ოზურგეთი" },
                    new LocalizedCityName { Id = 18, CityId = 9, LanguageCode = "EN", Name = "Ozurgeti" }
                ]
            },
            new()
            {
                City = new City { Id = 10, Code = "SAM" },
                LocalizedNames =
                [
                    new LocalizedCityName { Id = 19, CityId = 10, LanguageCode = "GE", Name = "სამტრედია" },
                    new LocalizedCityName { Id = 20, CityId = 10, LanguageCode = "EN", Name = "Samtredia" }
                ]
            },
            new()
            {
                City = new City { Id = 11, Code = "AKH" },
                LocalizedNames =
                [
                    new LocalizedCityName { Id = 21, CityId = 11, LanguageCode = "GE", Name = "ახალციხე" },
                    new LocalizedCityName { Id = 22, CityId = 11, LanguageCode = "EN", Name = "Akhaltsikhe" }
                ]
            },
            new()
            {
                City = new City { Id = 12, Code = "KHA" },
                LocalizedNames =
                [
                    new LocalizedCityName { Id = 23, CityId = 12, LanguageCode = "GE", Name = "ხაშური" },
                    new LocalizedCityName { Id = 24, CityId = 12, LanguageCode = "EN", Name = "Khashuri" }
                ]
            }
        };

        modelBuilder.Entity<City>().HasData(citySeedData.Select(x => x.City).ToArray());
        modelBuilder.Entity<LocalizedCityName>().HasData(citySeedData.SelectMany(x => x.LocalizedNames).ToArray());
    }
}