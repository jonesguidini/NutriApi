using Nutrivida.Domain.Entities;

namespace Nutrivida.Domain.VMs
{
    public class SaleVM : BaseEntity
    {
        public decimal Value { get; set; }
        public string Description { get; set; }
        public int SaleCategoryId { get; set; }
        public string SaleCategory { get; set; }
        public int FinancialRecordId { get; set; }
    }
}