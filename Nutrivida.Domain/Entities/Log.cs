using System;

namespace Nutrivida.Domain.Entities
{
    public class Log : BaseEntity
    {
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}