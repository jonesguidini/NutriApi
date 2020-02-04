using Nutrivida.Data.Context;
using Nutrivida.Domain.Contracts.Repositories;
using Nutrivida.Domain.Entities;

namespace Nutrivida.Data.Repositories
{
    public class FinancialRecordsRepository : RepositoryBase<FinancialRecord>, IFinancialRecordRepository
    {
        public FinancialRecordsRepository(SQLContext DataContext) : base(DataContext)
        {
        }
    }
}