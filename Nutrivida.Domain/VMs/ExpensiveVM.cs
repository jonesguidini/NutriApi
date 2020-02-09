using Nutrivida.Domain.Entities;

namespace Nutrivida.Domain.VMs
{
    public class ExpensiveVM : BaseEntity
    {
        public decimal Value { get; set; }
        public string Description { get; set; }
        public int ExpensiveCategoryId { get; set; }
        public string ExpensiveCategory { get; set; }
        public int FinancialRecordId { get; set; }
    }
}