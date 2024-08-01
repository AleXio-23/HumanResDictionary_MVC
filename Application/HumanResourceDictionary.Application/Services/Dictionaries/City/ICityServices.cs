using HumanResourceDictionary.Domain.DictionaryModels;
using HumanResourceDictionary.Shared.Models.Generic;

namespace HumanResourceDictionary.Application.Services.Dictionaries.City;

public interface ICityServices
{
    Task<ActionResultResponse<ICollection<CityDto>>> GetCities(CancellationToken cancellationToken);
}