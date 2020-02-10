using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Nutrivida.Domain.DTOs;
using Nutrivida.Domain.Entities;
using Nutrivida.Domain.VMs;

namespace Nutrivida.Domain.Contracts.Services
{
    public interface IExpensiveService : IServiceBase<Expensive>
    {
        Task<ExpensiveVM> Add(ExpensiveDTO obj);
        Task<ExpensiveVM> Update(ExpensiveDTO obj);
    }
}
