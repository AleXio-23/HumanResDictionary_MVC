namespace HumanResourceDictionary.Domain.DictionaryModels;

public class PhoneNumberTypesDto
{
    public int Id { get; set; }
    public string Code { get; set; }

    public ICollection<LocalizedPhoneNumberTypeNamesDto>? LocalizedPhoneNumberTypeNames { get; set; } = null;
}