namespace HumanResourceDictionary.Domain.UserModels;

public record UserRelationsDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RelatedUserId { get; set; }
    public int RelationTypeId { get; set; }
    public RelationTypesDto RelationType { get; set; } = default!;
}