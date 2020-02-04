using Nutrivida.Domain.Entities;
using System;

namespace Nutrivida.Domain.DTOs
{
    public class ExpensiveDto : BaseEntity
    {
        public double Value { get; set; }
        public Guid ExpensiveCategoryId { get; set; }
        public ExpensiveCategoryDto ExpensiveCategory { get; set; }
        public string Description { get; set; }
        public int FinancialRecordId { get; set; }
        public FinancialRecordDto FinancialRecord { get; set; }
    }
}