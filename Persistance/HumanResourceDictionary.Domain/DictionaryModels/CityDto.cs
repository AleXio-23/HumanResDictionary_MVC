using HumanResourceDictionary.Domain.UserModels;

namespace HumanResourceDictionary.Domain.DictionaryModels;

public record CityDto
{
    public int Id { get; set; }
    public string Code { get; set; } = default!;

    public ICollection<LocalizedCityNameDto>? LocalizedNames { get; set; } = new List<LocalizedCityNameDto>();
}