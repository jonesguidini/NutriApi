using System;

namespace Nutrivida.Domain.Entities
{
    public class Expensive : BaseEntity
    {
        public decimal Value { get; set; }
        public Guid ExpensiveCategoryId { get; set; }
        public ExpensiveCategory ExpensiveCategory { get; set; }
        public string Description { get; set; }
        public Guid FinancialRecordId { get; set; }
        public FinancialRecord FinancialRecord { get; set; }
    }
}