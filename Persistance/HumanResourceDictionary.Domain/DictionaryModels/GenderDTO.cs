namespace HumanResourceDictionary.Domain.DictionaryModels;

public record GenderDto
{
    public int Id { get; set; }
    public string Code { get; set; } = default!;


    public ICollection<LocalizedGenderNamesDto>? LocalizedGenderNames { get; set; } =
        new List<LocalizedGenderNamesDto>();
     
}