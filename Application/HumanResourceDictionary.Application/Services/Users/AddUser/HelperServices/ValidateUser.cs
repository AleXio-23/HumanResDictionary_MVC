using HumanResourceDictionary.Infrastructure.Entities;

namespace HumanResourceDictionary.Application.Services.Users.AddUser.HelperServices;

public static class ValidateUser
{
    public static bool IsValidUser(this User? user)
    {
        return user is { Id: > 0 };
    }
}