using System.Collections.Generic;

namespace Nutrivida.Domain.Entities
{
    public class SaleCategory : DeletedEntity
    {
        public string Category { get; set; }
        public ICollection<Sale> Sales { get; set; }

        //public ICollection<HistoricalRegisterByUser> HistoricalRegisters { get; set; }
    }
}