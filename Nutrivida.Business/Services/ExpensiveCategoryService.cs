using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Nutrivida.Domain.Contracts.FluentValidation;
using Nutrivida.Domain.Contracts.Managers;
using Nutrivida.Domain.Contracts.Repositories;
using Nutrivida.Domain.Contracts.Services;
using Nutrivida.Domain.DTOs;
using Nutrivida.Domain.Entities;
using Nutrivida.Domain.Entities.FluentValidation;

namespace Nutrivida.Business.Services
{
    public class ExpensiveCategoryService : ServiceBase<ExpensiveCategory>, IExpensiveCategoryService
    {
        private readonly ExpensiveCategoryValidation validation;
        private readonly IMapper mapper;
        public ExpensiveCategoryService(ExpensiveCategoryValidation _validation, IExpensiveCategoryRepository _repository, INotificationManager _gerenciadorNotificacoes, IMapper _mapper, IFluentValidation<ExpensiveCategory> _fluentValidation) : base(_repository, _gerenciadorNotificacoes, _mapper, _fluentValidation)
        {
            validation = _validation;
            mapper = _mapper;
        }

        public async Task<ExpensiveCategory> Add(ExpensiveCategoryDTO objDTO)
        {
            // validação Fluent Validation da DTO
            var validacao = await validation.ValidateAsync(objDTO);

            if (!validacao.IsValid)
            {
                await Notify(validacao);
                return null;
            }

            var obj = mapper.Map<ExpensiveCategory>(objDTO);
            return await base.Add(obj);
        }

        public async Task<ExpensiveCategory> Update(ExpensiveCategoryDTO objDTO)
        {
            // validação Fluent Validation da DTO
            var validacao = await validation.ValidateAsync(objDTO);

            if (!validacao.IsValid)
            {
                await Notify(validacao);
                return null;
            }

            var obj = mapper.Map<ExpensiveCategory>(objDTO);
            return await base.Update(obj);
        }
    }
}
