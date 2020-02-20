using AutoMapper;
using Nutrivida.Domain.Contracts.FluentValidation;
using Nutrivida.Domain.Contracts.Managers;
using Nutrivida.Domain.Contracts.Repositories;
using Nutrivida.Domain.Contracts.Services;
using Nutrivida.Domain.DTOs;
using Nutrivida.Domain.Entities;
using Nutrivida.Domain.Entities.FluentValidation;
using Nutrivida.Domain.VMs;
using System.Threading.Tasks;

namespace Nutrivida.Business.Services
{
    public class SaleService : ServiceBase<Sale>, ISaleService
    {
        private readonly SaleValidation validation;
        private readonly IMapper mapper;
        public SaleService(SaleValidation _validation, ISaleRepository _repository, INotificationManager _gerenciadorNotificacoes, IMapper _mapper, IFluentValidation<Sale> _fluentValidation, IAuthService _authService) : base(_repository, _gerenciadorNotificacoes, _mapper, _fluentValidation, _authService)
        {
            validation = _validation;
            mapper = _mapper;
        }

        public async Task<SaleVM> Add(SaleDTO objDTO)
        {
            // validação Fluent Validation da DTO
            var validacao = await validation.ValidateAsync(objDTO);

            if (!validacao.IsValid)
            {
                await Notify(validacao);
                return null;
            }

            var obj = mapper.Map<Sale>(objDTO);
            var objVM = mapper.Map<SaleVM>(await base.Add(obj));

            return objVM;
        }

        public async Task<SaleVM> Update(SaleDTO objDTO)
        {
            // validação Fluent Validation da DTO
            var validacao = await validation.ValidateAsync(objDTO);

            if (!validacao.IsValid)
            {
                await Notify(validacao);
                return null;
            }

            var obj = mapper.Map<Sale>(objDTO);
            var objVM = mapper.Map<SaleVM>(await base.Update(obj));

            return objVM;
        }
    }
}
