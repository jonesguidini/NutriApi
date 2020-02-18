using System;

namespace Nutrivida.Domain.Entities
{
    public class Log : DeletedEntity
    {
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}