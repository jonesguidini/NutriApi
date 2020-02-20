using System.Linq;
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
using Nutrivida.Domain.VMs;

namespace Nutrivida.Business.Services
{
    public class ExpensiveCategoryService : ServiceBase<ExpensiveCategory>, IExpensiveCategoryService
    {
        private readonly ExpensiveCategoryValidation validation;
        private readonly IMapper mapper;
        public ExpensiveCategoryService(ExpensiveCategoryValidation _validation, IExpensiveCategoryRepository _repository, INotificationManager _gerenciadorNotificacoes, IMapper _mapper, IFluentValidation<ExpensiveCategory> _fluentValidation, IAuthService _authService) : base(_repository, _gerenciadorNotificacoes, _mapper, _fluentValidation, _authService)
        {
            validation = _validation;
            mapper = _mapper;
        }

        public async Task<ExpensiveCategoryVM> Add(ExpensiveCategoryDTO objDTO)
        {
            // validação Fluent Validation da DTO
            var validacao = await validation.ValidateAsync(objDTO);

            if (!validacao.IsValid)
            {
                await Notify(validacao);
                return null;
            }

            //valida se o nome da categoria informada já existe em outro registro
            if(repository.Search(x => x.Category.ToLower() == objDTO.Category.ToLower()).Result.Any())
            {
                await Notify("Categoria", "Já existe uma categoria cadastrada com esse nome.");
                return null;
            }

            var obj = mapper.Map<ExpensiveCategory>(objDTO);
            var objVM = mapper.Map<ExpensiveCategoryVM>(await base.Add(obj));

            return objVM;
        }

        public async Task<ExpensiveCategoryVM> Update(ExpensiveCategoryDTO objDTO)
        {
            // validação Fluent Validation da DTO
            var validacao = await validation.ValidateAsync(objDTO);

            if (!validacao.IsValid)
            {
                await Notify(validacao);
                return null;
            }

            //valida se o nome da categoria informada já existe em outro registro
            if (repository.Search(x => x.Category.ToLower() == objDTO.Category.ToLower() && x.Id != objDTO.Id ).Result.Any())
            {
                await Notify("Categoria", "Já existe uma categoria cadastrada com esse nome.");
                return null;
            }

            var obj = mapper.Map<ExpensiveCategory>(objDTO);
            var objVM = mapper.Map<ExpensiveCategoryVM>(await base.Update(obj));

            return objVM;
        }
    }
}
