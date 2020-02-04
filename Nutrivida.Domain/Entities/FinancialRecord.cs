using System;
using System.Collections.Generic;

namespace Nutrivida.Domain.Entities
{
    public class FinancialRecord : BaseEntity
    {
        public string SalesObservation { get; set; }
        public string ExpensivesObservation { get; set; }
        public int? NumMeals { get; set; }
        public int? NumProducts { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Sale> Sales { get; set; }

        public ICollection<Expensive> Expensives { get; set; }

        //public ICollection<HistoricalRegisterByUser> HistoricalRegisters { get; set; }
    }
}