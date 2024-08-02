namespace HumanResourceDictionary.Infrastructure.Entities;

public class RelationTypes
{
    public int Id { get; set; }
    public string Code { get; set; } = default!;


    public ICollection<LocalizedRelationTypeNames>? LocalizedRelationTypeNames { get; set; } =
        new List<LocalizedRelationTypeNames>();

    public ICollection<UserRelations>? UserRelations { get; set; } = new List<UserRelations>();
}