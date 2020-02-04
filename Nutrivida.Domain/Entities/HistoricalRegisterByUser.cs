using System;
using System.Collections.Generic;
using System.Text;

namespace Nutrivida.Domain.Entities
{
    public abstract class HistoricalRegisterByUser : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public byte TypeOfAction { get; set; }
        public DateTime Date { get; set; }
        public string PreviousValue { get; set; }
        public string UpdatedValue { get; set; }

        //public ICollection<ExpensiveCategory> ExpensiveCategories { get; set; }
        //public ICollection<SaleCategory> SaleCategories { get; set; }
        //public ICollection<FinancialRecord> FinancialRecords { get; set; }
    }
}
