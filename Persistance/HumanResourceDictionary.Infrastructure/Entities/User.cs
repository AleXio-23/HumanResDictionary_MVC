namespace HumanResourceDictionary.Infrastructure.Entities;

public class User
{
    public int Id { get; set; }
    public string Firstname { get; set; } = default!;
    public int GenderId { get; set; }
    public string PersonalNumber { get; set; } = default!;
    public DateTime BirthDate { get; set; }

    public int CityId { get; set; }

    //ტელეფონის ნო,რების ცხრილ იცალკე
    public string? AvatarUrl { get; set; }

    public Gender Gender { get; set; } = default!;
    public City City { get; set; } = default!;
}