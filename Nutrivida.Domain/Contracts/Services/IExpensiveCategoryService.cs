using System.Threading.Tasks;
using Nutrivida.Domain.DTOs;
using Nutrivida.Domain.Entities;
using Nutrivida.Domain.VMs;

namespace Nutrivida.Domain.Contracts.Services
{
    public interface IExpensiveCategoryService: IServiceBase<ExpensiveCategory>
    {
        Task<ExpensiveCategoryVM> Add(ExpensiveCategoryDTO obj);

        Task<ExpensiveCategoryVM> Update(ExpensiveCategoryDTO obj);
    }
}
