namespace HumanResourceDictionary.Infrastructure.Entities;

public class LocalizedGenderNames
{
    public int Id { get; set; }
    public int GenderId { get; set; }
    public string LanguageCode { get; set; } = default!;
    public string Name { get; set; } = default!;
     
    public Gender Gender { get; set; } = default!;
}