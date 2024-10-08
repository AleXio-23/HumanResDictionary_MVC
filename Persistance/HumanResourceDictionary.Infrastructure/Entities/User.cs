using FluentValidation;

namespace HumanResourceDictionary.Infrastructure.Entities;

public class User
{
    public int Id { get; set; }
    public string Firstname { get; set; } = default!;
    public string Lastname { get; set; } = default!;
    public int GenderId { get; set; }
    public string PersonalNumber { get; set; } = default!;
    public DateTime BirthDate { get; set; }

    public int CityId { get; set; }

    //ტელეფონის ნო,რების ცხრილ იცალკე
    public string? AvatarUrl { get; set; }

    public Gender Gender { get; set; } = default!;
    public City City { get; set; } = default!;

    public virtual ICollection<PhoneNumberDictionary>? PhoneNumberDictionary { get; set; } = new List<PhoneNumberDictionary>();
    public virtual ICollection<UserRelations>? UserRelations { get; set; } = new List<UserRelations>();
    public virtual ICollection<UserRelations>? RelatedUserRelations { get; set; } = new List<UserRelations>();
    
    
}
