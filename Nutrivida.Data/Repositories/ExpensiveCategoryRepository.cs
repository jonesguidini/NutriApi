using Nutrivida.Data.Context;
using Nutrivida.Domain.Contracts.Managers;
using Nutrivida.Domain.Contracts.Repositories;
using Nutrivida.Domain.Entities;

namespace Nutrivida.Data.Repositories
{
    public class ExpensiveCategoryRepository : RepositoryBase<ExpensiveCategory>, IExpensiveCategoryRepository
    {
        public ExpensiveCategoryRepository(SQLContext DataContext, INotificationManager _gerenciadorNotificacoes) : base(DataContext, _gerenciadorNotificacoes)
        {
        }
    }
}