using HumanResourceDictionary.Domain.UserModels;
using HumanResourceDictionary.Infrastructure.Entities;
using HumanResourceDictionary.Infrastructure.Interfaces;

namespace HumanResourceDictionary.Application.Services.Users.AddUser.HelperServices;

public static class AssignPhoneNumbersToUser
{
    public static async Task AssignPhoneNumbers(this User user,
        List<PhoneNumberDictionaryDto> assignedUserPhoneNumbers,
        IHumanResourceUnitOfWork context,
        CancellationToken cancellationToken)
    {
        var entityValueList = assignedUserPhoneNumbers.Select(x => new PhoneNumberDictionary()
        {
            UserId = user.Id,
            NumberTypeId = x.NumberTypeId,
            PhoneNumber = x.PhoneNumber
        }).ToList();

        await context.PhoneNumbersDictionary.AddRangeAsync(entityValueList, cancellationToken).ConfigureAwait(false);
    }
}