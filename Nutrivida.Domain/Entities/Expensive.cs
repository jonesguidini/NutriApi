using System;

namespace Nutrivida.Domain.Entities
{
    public class Expensive : DeletedEntity
    {
        public decimal Value { get; set; }
        public string Description { get; set; }
        public int ExpensiveCategoryId { get; set; }
        public ExpensiveCategory ExpensiveCategory { get; set; }
        public int FinancialRecordId { get; set; }
        public FinancialRecord FinancialRecord { get; set; }

    }
}