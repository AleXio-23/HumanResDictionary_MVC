using HumanResourceDictionary.Domain.DictionaryModels;
using HumanResourceDictionary.Domain.UserModels;
using HumanResourceDictionary.Infrastructure.Interfaces;
using HumanResourceDictionary.Shared.Models.Generic;
using Microsoft.EntityFrameworkCore;

namespace HumanResourceDictionary.Application.Services.Users.GetUsers;

public class GetUsersService(IHumanResourceUnitOfWork dataContext) : IGetUsersService
{
    public async Task<ActionResultResponse<IEnumerable<UserDto>>> Execute(CancellationToken cancellationToken)
    {
        var getUsers = await dataContext.Users.All.Include(x => x.City).ThenInclude(c => c.LocalizedNames)
            .Include(x => x.Gender).AsNoTracking().Select(
                x => new UserDto()
                {
                    Id = x.Id,
                    Firstname = x.Firstname,
                    Lastname = x.Lastname,
                    GenderId = x.GenderId,
                    PersonalNumber = x.PersonalNumber,
                    BirthDate = x.BirthDate,
                    CityId = x.CityId,
                    AvatarUrl = x.AvatarUrl,
                    City = new CityDto()
                    {
                        Id = x.CityId,
                        LocalizedNames = x.City.LocalizedNames!.Select(l => new LocalizedCityNameDto()
                        {
                            Id = l.Id,
                            Name = l.Name
                        }).ToList()
                    },
                    Gender = new GenderDto()
                    {
                        Id = x.GenderId,
                        LocalizedGenderNames = x.Gender.LocalizedGenderNames != null
                            ? x.Gender.LocalizedGenderNames.Select(g => new LocalizedGenderNamesDto()
                            {
                                Id = g.Id,
                                Name = g.Name
                            }).ToList()
                            : null
                    }
                }).AsSplitQuery().ToListAsync(cancellationToken);

        return ActionResultResponse<IEnumerable<UserDto>>.SuccessResult(getUsers);
    }
}