namespace HumanResourceDictionary.Domain.DictionaryModels;

public record LocalizedRelationTypeNamesDto
{
    public int Id { get; set; }
    public int RelationTypeId { get; set; }
    public string LanguageCode { get; set; } = default!;
    public string Name { get; set; } = default!;
}