namespace HumanResourceDictionary.Infrastructure.Entities;

public class Gender
{
    public int Id { get; set; }
    public string Code { get; set; } = default!;

    public ICollection<LocalizedGenderNames>? LocalizedGenderNames { get; set; } = new List<LocalizedGenderNames>();

    public ICollection<User> Users { get; set; } = new List<User>();
}