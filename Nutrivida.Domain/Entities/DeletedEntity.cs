using System;
using System.Collections.Generic;
using System.Text;

namespace Nutrivida.Domain.Entities
{
    public abstract class DeletedEntity : BaseEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime? DateDelited { get; set; }
        public int? DeletedByUserId { get; set; }
        public User? DeletedByUser { get; set; }
    }
}
