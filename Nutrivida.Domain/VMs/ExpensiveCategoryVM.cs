using Nutrivida.Domain.Entities;

namespace Nutrivida.Domain.VMs
{
    public class ExpensiveCategoryVM : DeletedEntityVM
    {
        public string Category { get; set; }
    }
}