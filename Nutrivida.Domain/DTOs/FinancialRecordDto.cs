using System;
using System.Collections.Generic;
using Nutrivida.Domain.Entities;

namespace Nutrivida.Domain.DTOs
{
    public class FinancialRecordDto : BaseEntity
    {
        public ICollection<SaleDto> Sales { get; set; }
        public string SalesObservation { get; set; }
        public ICollection<ExpensiveDto> Expensives { get; set; }
        public string ExpensivesObservation { get; set; }
        public int NumMeals { get; set; }
        public int NumProducts { get; set; }
    }
}