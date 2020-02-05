using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutrivida.Domain.Contracts.Managers;
using Nutrivida.Domain.Contracts.Services;
using Nutrivida.Domain.DTOs;
using Nutrivida.Domain.Entities;
using Nutrivida.Domain.VMs;

namespace Nutrivida.API.Controllers
{
    [Authorize]
    [Route("api/expensivecategories")]
    [ApiController]
    public class ExpensiveCategoriesController : APIController
    {
        private readonly IExpensiveCategoryService _expensiveCategoryService;
        private readonly IMapper _mapper;
        public ExpensiveCategoriesController(IExpensiveCategoryService expensiveCategoryService, IMapper mapper, INotificationManager _gerenciadorNotificacoes) : base(_gerenciadorNotificacoes)
        {
            _mapper = mapper;
            _expensiveCategoryService = expensiveCategoryService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ExpensiveCategoryVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var expensiveCategories = await _expensiveCategoryService.GetAll();
            var listExpensiveCategoryVM = _mapper.Map<IEnumerable<ExpensiveCategoryVM>>(expensiveCategories);
            return CustomResponse(listExpensiveCategoryVM);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ExpensiveCategoryVM), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var expensiveCategory = await _expensiveCategoryService.GetById(id);

            if (!expensiveCategory.Any())
            {
                NotificarError("Categoria de Despesa", "A Categoria de despesa informada não existe.");
                return CustomResponse();
            }

            ExpensiveCategoryVM expensiveCategoryVM = _mapper.Map<ExpensiveCategoryVM>(expensiveCategory.SingleOrDefault());
            return CustomResponse(expensiveCategoryVM);
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(ExpensiveCategoryDTO expensiveCategoryDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            // mapeamento
            var expensiveCategory = _mapper.Map<ExpensiveCategoryDTO, ExpensiveCategory>(expensiveCategoryDTO);

            await _expensiveCategoryService.Add(expensiveCategory);

            return CustomResponse("Categoria de despesa cadastrada com sucesso");
        }

        [HttpPut]
        [Route("update/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(int id, ExpensiveCategoryDTO expensiveCategoryDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var expensiveCategoryBanco = await _expensiveCategoryService.GetById(id);

            if (expensiveCategoryBanco == null)
            {
                NotificarError("Categoria de Despesa", "A Categoria de despesa informada não existe.");
                return CustomResponse();
            }

            // mapeamento
            var expensiveCategoryToUpdate = _mapper.Map(expensiveCategoryDTO, expensiveCategoryBanco).SingleOrDefault();
            await _expensiveCategoryService.Update(expensiveCategoryToUpdate);

            return CustomResponse("Categoria de despesas atualizada com sucesso!");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var expensiveCategory = await _expensiveCategoryService.GetById(id);

            if (expensiveCategory == null)
            {
                NotificarError("Categoria de Despesa", "A Categoria de despesa informada não existe.");
                return CustomResponse();
            }

            await _expensiveCategoryService.Delete(id);

            return CustomResponse("Categoria de despesa excluida com sucesso!");
        }
    }
}