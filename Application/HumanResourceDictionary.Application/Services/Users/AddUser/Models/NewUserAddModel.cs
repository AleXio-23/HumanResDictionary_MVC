using HumanResourceDictionary.Domain.UserModels;

namespace HumanResourceDictionary.Application.Services.Users.AddUser.Models;

public record NewUserAddModel
{
    public UserDto User { get; set; }
    public List<PhoneNumberDictionaryDto> AssignedUserPhoneNumbers { get; set; } = [];

    public List<int> RelatedUsersId { get; set; } = [];
}