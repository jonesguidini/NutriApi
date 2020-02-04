using System;

namespace Nutrivida.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public double Value { get; set; }
        public Guid SaleCategoryId { get; set; }
        public SaleCategory SaleCategory { get; set; }
        public Guid FinancialRecordId { get; set; }
        public FinancialRecord FinancialRecord { get; set; }
    }
}