namespace HumanResourceDictionary.Infrastructure.Entities;

public class PhoneNumberDictionary
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int NumberTypeId { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;


    public PhoneNumberTypes PhoneNumberType { get; set; } = default!;

    public User User { get; set; } = default!;
}