using Nutrivida.Domain.Entities;

namespace Nutrivida.Domain.VMs
{
    public class FinancialRecordVM : BaseEntity
    {
        public string SalesObservation { get; set; }
        public string ExpensivesObservation { get; set; }
        public int? NumMeals { get; set; }
        public int? NumProducts { get; set; }
        public int UserId { get; set; }
    }
}