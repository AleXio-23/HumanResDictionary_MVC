using HumanResourceDictionary.Domain.DictionaryModels;

namespace HumanResourceDictionary.Domain.UserModels;

public class UserDto
{
    public int Id { get; set; }
    public string Firstname { get; set; } = default!;
    public string Lastname { get; set; } = default!;
    public int GenderId { get; set; }
    public string PersonalNumber { get; set; } = default!;
    public DateTime BirthDate { get; set; }

    public int CityId { get; set; }

    public string? AvatarUrl { get; set; }

    public GenderDto Gender { get; set; } = default!;
    public CityDto City { get; set; } = default!;
}