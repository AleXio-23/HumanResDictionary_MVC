using HumanResourceDictionary.Domain.DictionaryModels;

namespace HumanResourceDictionary.Domain.UserModels;

public class PhoneNumberDictionaryDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int NumberTypeId { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;

    public PhoneNumberTypesDto? PhoneNumberType { get; set; } = null;
}