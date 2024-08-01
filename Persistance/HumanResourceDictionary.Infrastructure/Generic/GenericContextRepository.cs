using HumanResourceDictionary.Infrastructure.Data;
using HumanResourceDictionary.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace HumanResourceDictionary.Infrastructure.Generic;

public class GenericContextRepository<T>(DbContext context) : Repository<T>(context)
    where T : class
{
    public HumanResourceDbContext Context => (base.Context as HumanResourceDbContext)!;
 
}