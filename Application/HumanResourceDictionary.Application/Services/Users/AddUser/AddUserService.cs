using HumanResourceDictionary.Application.Services.Users.AddUser.HelperServices;
using HumanResourceDictionary.Application.Services.Users.AddUser.Models;
using HumanResourceDictionary.Infrastructure.Interfaces;

namespace HumanResourceDictionary.Application.Services.Users.AddUser;

public class AddUserService(IHumanResourceUnitOfWork dataContext): IAddUserService
{
    public async Task Execute(NewUserAddModel request, CancellationToken cancellationToken)
    {
        await request.ValidateUserPersonalNumberExistence(dataContext);
        var user = await request.User
            .RegisterUser(dataContext, cancellationToken)
            .ConfigureAwait(false);

        if (user.IsValidUser())
        {
            if (request.AssignedUserPhoneNumbers.Count != 0)
            {
                await user!.AssignPhoneNumbers(request.AssignedUserPhoneNumbers, dataContext, cancellationToken);
            }
        }
        
        //დასამთავრებელი
    }
}