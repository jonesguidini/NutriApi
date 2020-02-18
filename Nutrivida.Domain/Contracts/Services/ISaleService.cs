using System.Threading.Tasks;
using Nutrivida.Domain.DTOs;
using Nutrivida.Domain.Entities;
using Nutrivida.Domain.VMs;

namespace Nutrivida.Domain.Contracts.Services
{
    public interface ISaleService : IServiceBase<Sale>
    {
        Task<SaleVM> Add(SaleDTO obj);
        Task<SaleVM> Update(SaleDTO obj);
    }
}
