using System;

namespace Nutrivida.Domain.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public DateTime Created { get; set; }

        // Config for Deleted registers
        public DateTime? DateDeleted { get; set; }
        public int? DeletedByUserId { get; set; }
    }
}
