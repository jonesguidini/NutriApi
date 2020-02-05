using System;
using Nutrivida.Domain.Entities;

namespace Nutrivida.Domain.DTOs
{
    public class LogDto : BaseEntity
    {
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}