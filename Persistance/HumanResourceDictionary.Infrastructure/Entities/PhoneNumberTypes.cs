namespace HumanResourceDictionary.Infrastructure.Entities;

public class PhoneNumberTypes
{
    public int Id { get; set; }
    public string Code { get; set; }


    public ICollection<LocalizedPhoneNumberTypeNames>? LocalizedPhoneNumberTypeNames { get; set; } =
        new List<LocalizedPhoneNumberTypeNames>();
    public ICollection<PhoneNumberDictionary>? PhoneNumberDictionaries { get; set; } =
        new List<PhoneNumberDictionary>();
}