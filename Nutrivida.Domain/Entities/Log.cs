using System;

namespace Nutrivida.Domain.Entities
{
    public class Log : BaseEntity
    {
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}