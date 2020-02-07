using System.Threading.Tasks;
using Nutrivida.Domain.DTOs;
using Nutrivida.Domain.Entities;
using Nutrivida.Domain.VMs;

namespace Nutrivida.Domain.Contracts.Services
{
    public interface ISaleCategoryService : IServiceBase<SaleCategory>
    {
        Task<SaleCategoryVM> Add(SaleCategoryDTO obj);
        Task<SaleCategoryVM> Update(SaleCategoryDTO obj);
    }
}
