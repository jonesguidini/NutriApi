using Nutrivida.Domain.Entities;

namespace Nutrivida.Domain.VMs
{
    public class SaleCategoryVM : DeletedEntityVM
    {
        public string Category { get; set; }
    }
}