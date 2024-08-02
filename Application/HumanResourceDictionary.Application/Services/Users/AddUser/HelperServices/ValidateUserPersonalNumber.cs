using HumanResourceDictionary.Application.Services.Users.AddUser.Models;
using HumanResourceDictionary.Domain.Constants;
using HumanResourceDictionary.Infrastructure.Interfaces;

namespace HumanResourceDictionary.Application.Services.Users.AddUser.HelperServices;

public static class ValidateUserPersonalNumber
{
    public static async Task ValidateUserPersonalNumberExistence(this NewUserAddModel request,
        IHumanResourceUnitOfWork context)
    {
        if (await context.Users.AnyAsync(x => x.PersonalNumber == request.User.PersonalNumber))
        {
            throw new ArgumentException(ErrorMessageConstants.PersonalNumberAlreadyExist);
        }
    }
}