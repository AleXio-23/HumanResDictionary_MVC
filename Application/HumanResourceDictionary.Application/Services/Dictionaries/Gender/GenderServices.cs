using HumanResourceDictionary.Domain.DictionaryModels;
using HumanResourceDictionary.Infrastructure.Interfaces;
using HumanResourceDictionary.Shared.Models.Generic;
using Microsoft.EntityFrameworkCore;

namespace HumanResourceDictionary.Application.Services.Dictionaries.Gender;

public class GenderServices(IHumanResourceUnitOfWork dataContext) : IGenderServices
{
    public async Task<ActionResultResponse<ICollection<GenderDto>>> GetGenders(CancellationToken cancellationToken)
    {
        var result = await dataContext.Genders.All.AsNoTracking()
            .Include(x => x.LocalizedGenderNames)
            .Select(x => new GenderDto()
            {
                Id = x.Id,
                Code = x.Code,
                LocalizedGenderNames = x.LocalizedGenderNames!.Select(l => new LocalizedGenderNamesDto()
                {
                    Id = l.Id,
                    GenderId = l.GenderId,
                    LanguageCode = l.LanguageCode,
                    Name = l.Name
                }).ToList()
            }).ToListAsync(cancellationToken).ConfigureAwait(false);

        return ActionResultResponse<ICollection<GenderDto>>.SuccessResult(result);
    }
}