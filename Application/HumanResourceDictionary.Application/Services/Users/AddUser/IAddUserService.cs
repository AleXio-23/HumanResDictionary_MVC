using HumanResourceDictionary.Application.Services.Users.AddUser.Models;

namespace HumanResourceDictionary.Application.Services.Users.AddUser;

public interface IAddUserService
{
    Task Execute(NewUserAddModel request, CancellationToken cancellationToken);
}