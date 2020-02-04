using System;
using System.Collections.Generic;

namespace Nutrivida.Domain.Entities
{
    public class FinancialRecord : BaseEntity
    {
        public ICollection<Sale> Sales { get; set; }
        public string SalesObservation { get; set; }
        public ICollection<Expensive> Expensives { get; set; }
        public string ExpensivesObservation { get; set; }
        public int NumMeals { get; set; }
        public int NumProducts { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}