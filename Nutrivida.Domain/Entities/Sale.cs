using System;

namespace Nutrivida.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public decimal Value { get; set; }
        public string Description { get; set; }
        public int SaleCategoryId { get; set; }
        public SaleCategory SaleCategory { get; set; }
        public int FinancialRecordId { get; set; }
        public FinancialRecord FinancialRecord { get; set; }
    }
}