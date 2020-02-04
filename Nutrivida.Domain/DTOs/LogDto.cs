using System;
using Nutrivida.Domain.Entities;

namespace Nutrivida.Domain.DTOs
{
    public class LogDto : BaseEntity
    {
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public UserDto User { get; set; }
    }
}