using Nutrivida.Domain.Entities;
using System;

namespace Nutrivida.Domain.DTOs
{
    public class SaleDto : BaseEntity
    {
        public decimal Value { get; set; }
        public string Description { get; set; }
        public int SaleCategoryId { get; set; }
        public int FinancialRecordId { get; set; }
    }
}