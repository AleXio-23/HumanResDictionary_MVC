using HumanResourceDictionary.Domain.UserModels;
using HumanResourceDictionary.Shared.Models.Generic;

namespace HumanResourceDictionary.Application.Services.Users.GetUsers;

public interface IGetUsersService
{
    Task<ActionResultResponse<IEnumerable<UserDto>>> Execute(CancellationToken cancellationToken);
}