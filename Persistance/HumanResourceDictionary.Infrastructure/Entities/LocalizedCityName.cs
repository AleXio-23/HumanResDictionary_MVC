namespace HumanResourceDictionary.Infrastructure.Entities;

public class LocalizedCityName
{ 
    public int Id { get; set; }
    public int CityId { get; set; }
    public string LanguageCode { get; set; } = default!;
    public string Name { get; set; } = default!;
     
    public City City { get; set; } = default!;
}