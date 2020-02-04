using System.Collections.Generic;

namespace Nutrivida.Domain.Entities
{
    public class ExpensiveCategory : BaseEntity
    {
        public string Category { get; set; }
        public ICollection<Expensive> Expensives { get; set; }
        //public ICollection<HistoricalRegisterByUser> HistoricalRegisters { get; set; }
    }
}