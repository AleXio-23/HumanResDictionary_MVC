using HumanResourceDictionary.Domain.DictionaryModels;
using HumanResourceDictionary.Shared.Models.Generic;

namespace HumanResourceDictionary.Application.Services.Dictionaries.Gender;

public interface IGenderServices
{
    Task<ActionResultResponse<ICollection<GenderDto>>> GetGenders(CancellationToken cancellationToken);
}