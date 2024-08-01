namespace HumanResourceDictionary.Infrastructure.Entities;

public class LocalizedPhoneNumberTypeNames
{
    public int Id { get; set; }
    public int PhoneNumberTypeId { get; set; }
    public string LanguageCode { get; set; } = default!;
    public string TypeName { get; set; } = default!;

    public PhoneNumberTypes PhoneNumberType { get; set; } = default!;
}