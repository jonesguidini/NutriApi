using Nutrivida.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nutrivida.Domain.Contracts.Repositories
{
    public interface ISaleRepository : IRepositoryBase<Sale>
    {
         Task<IEnumerable<Sale>> GetByFinancialId(Guid financialId);
    }
}