namespace HumanResourceDictionary.Infrastructure.Entities;

public class City
{
    public int Id { get; set; }
    public string Code { get; set; } = default!;

    public ICollection<LocalizedCityName>? LocalizedNames { get; set; } = new List<LocalizedCityName>();

    public ICollection<User>? Users { get; set; } = new List<User>();
}