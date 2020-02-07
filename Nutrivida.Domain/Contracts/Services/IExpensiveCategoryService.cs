using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Nutrivida.Domain.DTOs;
using Nutrivida.Domain.Entities;

namespace Nutrivida.Domain.Contracts.Services
{
    public interface IExpensiveCategoryService: IServiceBase<ExpensiveCategory>
    {
        Task<ExpensiveCategory> Add(ExpensiveCategoryDTO obj);

        Task<ExpensiveCategory> Update(ExpensiveCategoryDTO obj);
    }
}
