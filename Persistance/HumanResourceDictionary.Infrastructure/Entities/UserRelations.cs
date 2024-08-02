namespace HumanResourceDictionary.Infrastructure.Entities;

public class UserRelations
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RelatedUserId { get; set; }
    public int RelationTypeId { get; set; }
    
    
    public User User { get; set; } = default!;
    public User RelatedUser { get; set; } = default!;
    public RelationTypes RelationType { get; set; } = default!;
}