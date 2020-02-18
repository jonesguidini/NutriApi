using Nutrivida.Domain.Entities;

namespace Nutrivida.Domain.DTOs
{
    public class ExpensiveCategoryDTO : DeletedEntity
    {
        public string Category { get; set; }
    }
}