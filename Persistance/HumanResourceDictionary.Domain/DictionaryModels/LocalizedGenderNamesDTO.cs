namespace HumanResourceDictionary.Domain.DictionaryModels;

public record LocalizedGenderNamesDto
{
    public int Id { get; set; }
    public int GenderId { get; set; }
    public string LanguageCode { get; set; } = default!;
    public string Name { get; set; } = default!;
     
    public GenderDto Gender { get; set; } = default!;
}