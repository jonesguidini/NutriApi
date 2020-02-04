using Nutrivida.Domain.Entities;
using System;

namespace Nutrivida.Domain.DTOs
{
    public class SaleDto : BaseEntity
    {
        public double Value { get; set; }
        public int SaleCategoryId { get; set; }
        public SaleCategoryDto SaleCategory { get; set; }
        public int FinancialRecordId { get; set; }
        public FinancialRecordDto FinancialRecord { get; set; }
    }
}