using System.Collections.Generic;

namespace Nutrivida.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        //public ICollection<Log> Logs { get; set; }
        public ICollection<FinancialRecord> FinancialRecords { get; set; }
        //public ICollection<Expensive> Expensives { get; set; }
        //public ICollection<Sale> Sales { get; set; }
        //public ICollection<HistoricalRegisterByUser> HistoricalRegisters { get; set; }
    }
}