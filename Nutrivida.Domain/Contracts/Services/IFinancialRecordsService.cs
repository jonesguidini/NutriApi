using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Nutrivida.Domain.DTOs;
using Nutrivida.Domain.Entities;
using Nutrivida.Domain.VMs;

namespace Nutrivida.Domain.Contracts.Services
{
    public interface IFinancialRecordsService : IServiceBase<FinancialRecord>
    {
        Task<FinancialRecordVM> Add(FinancialRecordDTO obj);
        Task<FinancialRecordVM> Update(FinancialRecordDTO obj);
    }
}
