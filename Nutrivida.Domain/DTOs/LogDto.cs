using System;
using Nutrivida.Domain.Entities;

namespace Nutrivida.Domain.DTOs
{
    public class LogDTO : BaseEntity
    {
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}