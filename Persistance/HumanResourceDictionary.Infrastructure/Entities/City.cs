namespace HumanResourceDictionary.Infrastructure.Entities;

public class City
{
    public int Id { get; set; }
    public string Code { get; set; } = default!;
    public string LanguageCode { get; set; } = default!;
    public string Name { get; set; } = default!;

    public ICollection<User> Users { get; set; } = new List<User>();
}