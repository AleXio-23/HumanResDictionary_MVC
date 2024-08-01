namespace HumanResourceDictionary.Infrastructure.Entities;

public class LocalizedRelationTypeNames
{
    public int Id { get; set; }
    public int RelationTypeId { get; set; }
    public string LanguageCode { get; set; } = default!;
    public string Name { get; set; } = default!;
     
    public RelationTypes RelationType { get; set; } = default!;
}