using Nutrivida.Domain.Entities;

namespace Nutrivida.Domain.VMs
{
    public class LogVM : BaseEntity
    {
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}