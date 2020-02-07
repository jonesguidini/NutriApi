using System.Threading.Tasks;
using AutoMapper;
using Nutrivida.Domain.Contracts.FluentValidation;
using Nutrivida.Domain.Contracts.Managers;
using Nutrivida.Domain.Contracts.Repositories;
using Nutrivida.Domain.Contracts.Services;
using Nutrivida.Domain.DTOs;
using Nutrivida.Domain.Entities;
using Nutrivida.Domain.Entities.FluentValidation;
using Nutrivida.Domain.VMs;

namespace Nutrivida.Business.Services
{
    public class FinancialRecordsService : ServiceBase<FinancialRecord>, IFinancialRecordsService
    {
        private readonly FinancialRecordValidation validation;
        private readonly IMapper mapper;

        public FinancialRecordsService(FinancialRecordValidation _validation, IFinancialRecordRepository _repository, INotificationManager _gerenciadorNotificacoes, IMapper _mapper, IFluentValidation<FinancialRecord> _fluentValidation) : base(_repository, _gerenciadorNotificacoes, _mapper, _fluentValidation)
        {
            validation = _validation;
            mapper = _mapper;
        }

        public async Task<FinancialRecordVM> Add(FinancialRecordDTO objDTO)
        {
            // validação Fluent Validation da DTO
            var validacao = await validation.ValidateAsync(objDTO);

            if (!validacao.IsValid)
            {
                await Notify(validacao);
                return null;
            }

            var obj = mapper.Map<FinancialRecord>(objDTO);
            var objVM = mapper.Map<FinancialRecordVM>(await base.Add(obj));

            return objVM;
        }

        public async Task<FinancialRecordVM> Update(FinancialRecordDTO objDTO)
        {
            // validação Fluent Validation da DTO
            var validacao = await validation.ValidateAsync(objDTO);

            if (!validacao.IsValid)
            {
                await Notify(validacao);
                return null;
            }

            var obj = mapper.Map<FinancialRecord>(objDTO);
            var objVM = mapper.Map<FinancialRecordVM>(await base.Update(obj));

            return objVM;
        }
    }
}
