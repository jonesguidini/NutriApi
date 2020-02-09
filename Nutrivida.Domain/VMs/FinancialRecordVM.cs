using Nutrivida.Domain.Entities;
using System.Collections.Generic;

namespace Nutrivida.Domain.VMs
{
    public class FinancialRecordVM : BaseEntity
    {
        public string SalesObservation { get; set; }
        public string ExpensivesObservation { get; set; }
        public int? NumMeals { get; set; }
        public int? NumProducts { get; set; }
        public int UserId { get; set; }

        public decimal ValueTotalSales { get; set; }
        public decimal ValueTotalExpensives { get; set; }

        public ICollection<SaleVM> Sales { get; set; }
        public ICollection<ExpensiveVM> Expensives { get; set; }
    }
}