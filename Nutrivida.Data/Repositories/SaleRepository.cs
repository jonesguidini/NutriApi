using Microsoft.EntityFrameworkCore;
using Nutrivida.Data.Context;
using Nutrivida.Domain.Contracts.Managers;
using Nutrivida.Domain.Contracts.Repositories;
using Nutrivida.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrivida.Data.Repositories
{
    public class SaleRepository : RepositoryBase<Sale>, ISaleRepository
    {
        private readonly SQLContext _DataContext;
        private DbSet<Sale> _sales;

        public SaleRepository(SQLContext DataContext, INotificationManager _gerenciadorNotificacoes) : base(DataContext, _gerenciadorNotificacoes)
        {
            _DataContext = DataContext;
            _sales = DataContext.Set<Sale>();
        }

        public async Task<IEnumerable<Sale>> GetByFinancialId(int financialId)
        {
            return await _sales.Where(x => x.FinancialRecordId == financialId).ToListAsync();
        }
    }
}