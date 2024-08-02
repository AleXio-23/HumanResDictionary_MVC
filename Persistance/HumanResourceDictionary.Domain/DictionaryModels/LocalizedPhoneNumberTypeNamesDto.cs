namespace HumanResourceDictionary.Domain.DictionaryModels;

public class LocalizedPhoneNumberTypeNamesDto
{
    public int Id { get; set; }
    public int PhoneNumberTypeId { get; set; }
    public string LanguageCode { get; set; } = default!;
    public string TypeName { get; set; } = default!;
}