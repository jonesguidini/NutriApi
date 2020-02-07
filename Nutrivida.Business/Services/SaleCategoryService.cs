using System.Linq;
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
    public class SaleCategoryService : ServiceBase<SaleCategory>, ISaleCategoryService
    {
        private readonly SaleCategoryValidation validation;
        private readonly IMapper mapper;
        public SaleCategoryService(SaleCategoryValidation _validation, ISaleCategoryRepository _repository, INotificationManager _gerenciadorNotificacoes, IMapper _mapper, IFluentValidation<SaleCategory> _fluentValidation) : base(_repository, _gerenciadorNotificacoes, _mapper, _fluentValidation)
        {
            validation = _validation;
            mapper = _mapper;
        }

        public async Task<SaleCategoryVM> Add(SaleCategoryDTO objDTO)
        {
            // validação Fluent Validation da DTO
            var validacao = await validation.ValidateAsync(objDTO);

            if (!validacao.IsValid)
            {
                await Notify(validacao);
                return null;
            }

            //valida se o nome da categoria informada já existe em outro registro
            if (repository.Search(x => x.Category.ToLower() == objDTO.Category.ToLower()).Result.Any())
            {
                await Notify("Categoria", "Já existe uma categoria cadastrada com esse nome.");
                return null;
            }

            var obj = mapper.Map<SaleCategory>(objDTO);
            var objVM = mapper.Map<SaleCategoryVM>(await base.Add(obj));

            return objVM;
        }

        public async Task<SaleCategoryVM> Update(SaleCategoryDTO objDTO)
        {
            // validação Fluent Validation da DTO
            var validacao = await validation.ValidateAsync(objDTO);

            if (!validacao.IsValid)
            {
                await Notify(validacao);
                return null;
            }

            //valida se o nome da categoria informada já existe em outro registro
            if (repository.Search(x => x.Category.ToLower() == objDTO.Category.ToLower() && x.Id != objDTO.Id).Result.Any())
            {
                await Notify("Categoria", "Já existe uma categoria cadastrada com esse nome.");
                return null;
            }

            var obj = mapper.Map<SaleCategory>(objDTO);
            var objVM = mapper.Map<SaleCategoryVM>(await base.Update(obj));

            return objVM;
        }
    }
}
