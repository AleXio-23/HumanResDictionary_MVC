using HumanResourceDictionary.Domain.DictionaryModels;
using HumanResourceDictionary.Infrastructure.Interfaces;
using HumanResourceDictionary.Shared.Models.Generic;
using Microsoft.EntityFrameworkCore;

namespace HumanResourceDictionary.Application.Services.Dictionaries.City;

public class CityServices(IHumanResourceUnitOfWork dataContext): ICityServices
{
    public async Task<ActionResultResponse<ICollection<CityDto>>> GetCities(CancellationToken cancellationToken)
    {
        var result = await dataContext.Cities.All.AsNoTracking()
            .Include(x => x.LocalizedNames)
            .Select(x => new CityDto()
            {
                Id = x.Id,
                Code = x.Code,
                LocalizedNames = x.LocalizedNames!.Select(l => new LocalizedCityNameDto()
                {
                    Id = l.Id,
                    CityId = l.CityId,
                    LanguageCode = l.LanguageCode,
                    Name = l.Name
                }).ToList()
            }).ToListAsync(cancellationToken).ConfigureAwait(false);

        return ActionResultResponse<ICollection<CityDto>>.SuccessResult(result);
    }
}