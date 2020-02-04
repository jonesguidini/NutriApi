
using Nutrivida.Data.Context;
using Nutrivida.Domain.Contracts.Repositories;
using Nutrivida.Domain.Entities;

namespace Nutrivida.Data.Repositories
{
    public class ExpensiveRepository : RepositoryBase<Expensive>, IExpensiveRepository
    {
        public ExpensiveRepository(SQLContext DataContext) : base(DataContext)
        {
        }
    }
}