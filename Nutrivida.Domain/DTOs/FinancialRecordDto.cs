using System;
using System.Collections.Generic;
using Nutrivida.Domain.Entities;

namespace Nutrivida.Domain.DTOs
{
    public class FinancialRecordDTO : BaseEntity
    {
        public string SalesObservation { get; set; }
        public string ExpensivesObservation { get; set; }
        public int NumMeals { get; set; }
        public int NumProducts { get; set; }

        public ICollection<SaleDTO> Sales { get; set; }
        public ICollection<ExpensiveDTO> Expensives { get; set; }
    }
}