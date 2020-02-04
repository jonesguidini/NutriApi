using System.Collections.Generic;

namespace Nutrivida.Domain.Entities
{
    public class SaleCategory : BaseEntity
    {
        public string Category { get; set; }
        public ICollection<Sale> Sales { get; set; }

        //public ICollection<HistoricalRegisterByUser> HistoricalRegisters { get; set; }
    }
}