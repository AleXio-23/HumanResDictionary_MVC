namespace HumanResourceDictionary.Domain.DictionaryModels;

public record LocalizedCityNameDto
{
    public int Id { get; set; }
    public int CityId { get; set; }
    public string LanguageCode { get; set; } = default!;
    public string Name { get; set; } = default!;
     
    public CityDto City { get; set; } = default!;
}