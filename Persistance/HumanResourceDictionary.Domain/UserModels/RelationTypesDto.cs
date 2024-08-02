using HumanResourceDictionary.Domain.DictionaryModels;

namespace HumanResourceDictionary.Domain.UserModels;

public record RelationTypesDto
{
    public int Id { get; set; }
    public string Code { get; set; } = default!;
    
    public ICollection<LocalizedRelationTypeNamesDto>? LocalizedRelationTypeNames { get; set; } =
        new List<LocalizedRelationTypeNamesDto>();
}