using System.Collections.Generic;
using Nutrivida.Domain.Entities;

namespace Nutrivida.Domain.DTOs
{
    public class UserDto : BaseEntity
    {
        public string Username { get; set; }
        public ICollection<LogDto> Logs { get; set; }
        public ICollection<FinancialRecordDto> FinancialRecords { get; set; }
        public string Email { get; set; }
    }
}