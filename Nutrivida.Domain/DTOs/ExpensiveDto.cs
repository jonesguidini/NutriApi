using Nutrivida.Domain.Entities;
using System;

namespace Nutrivida.Domain.DTOs
{
    public class ExpensiveDto : BaseEntity
    {
        public decimal Value { get; set; }
        public string Description { get; set; }
        public int ExpensiveCategoryId { get; set; }
        public int FinancialRecordId { get; set; }
    }
}