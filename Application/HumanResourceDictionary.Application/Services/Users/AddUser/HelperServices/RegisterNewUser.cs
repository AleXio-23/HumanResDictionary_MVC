using HumanResourceDictionary.Domain.UserModels;
using HumanResourceDictionary.Infrastructure.Entities;
using HumanResourceDictionary.Infrastructure.Interfaces;

namespace HumanResourceDictionary.Application.Services.Users.AddUser.HelperServices;

public static class RegisterNewUser
{
    public static async Task<User?> RegisterUser(this UserDto user, IHumanResourceUnitOfWork context,
        CancellationToken cancellationToken)
    {
        var newUser = new User()
        {
            Firstname = user.Firstname,
            Lastname = user.Lastname,
            GenderId = user.GenderId,
            PersonalNumber = user.PersonalNumber,
            BirthDate = user.BirthDate,
            CityId = user.CityId,
            AvatarUrl = user.AvatarUrl,
        };
        return await context.Users.AddAsync(newUser, cancellationToken).ConfigureAwait(false);
    }
}