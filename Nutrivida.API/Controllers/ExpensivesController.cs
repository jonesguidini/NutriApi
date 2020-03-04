using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutrivida.Domain.Contracts.Managers;
using Nutrivida.Domain.Contracts.Services;
using Nutrivida.Domain.DTOs;
using Nutrivida.Domain.Entities;
using Nutrivida.Domain.Filters;
using Nutrivida.Domain.Filters.OrderBy;
using Nutrivida.Domain.VMs;

namespace Nutrivida.API.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/expensives")]
    [ApiController]
    public class ExpensivesController : APIController
    {
        private readonly IExpensiveService _expensiveService;
        private readonly IMapper _mapper;
        public ExpensivesController(IExpensiveService expensiveService, IMapper mapper, INotificationManager _gerenciadorNotificacoes) : base(_gerenciadorNotificacoes)
        {
            _mapper = mapper;
            _expensiveService = expensiveService;
        }

        /// <summary>
        /// Retornar todas categorias de despesas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ExpensiveVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            List<string> includes = new List<string> { "ExpensiveCategory" };

            var expensiveCategories = await _expensiveService.GetAll(includes);
            var listExpensiveVM = _mapper.Map<IEnumerable<ExpensiveVM>>(expensiveCategories);
            return CustomResponse(listExpensiveVM);
        }

        /// <summary>
        /// Retornar categoria de despesa filtrado pelo parametro 'id'
        /// </summary>
        /// <param name="id">Parâmetro para filtro por ID </param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ExpensiveVM), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            List<string> includes = new List<string> { "ExpensiveCategory" };
            var expensiveCategory = await _expensiveService.GetById(id, includes);

            ExpensiveVM expensiveCategoryVM = _mapper.Map<ExpensiveVM>(expensiveCategory);
            return CustomResponse(expensiveCategoryVM);
        }

        /// <summary>
        /// Criar nova categoria de despesa
        /// </summary>
        /// <param name="expensiveDTO">Objeto informado para cadastro do registro</param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(ExpensiveDTO expensiveDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _expensiveService.Add(expensiveDTO);
            return CustomResponse("Categoria de despesa cadastrada com sucesso");
        }

        /// <summary>
        /// Atualizar categoria de despesa
        /// </summary>
        /// <param name="id">Parâmetro para filtro da categoria a ser alterada</param>
        /// <param name="expensiveDTO">Objeto da categoria a ser alterada </param>
        /// <returns></returns>
        [HttpPut]
        [Route("update/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(int id, ExpensiveDTO expensiveDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var expensiveCategoryBanco = await _expensiveService.GetById(id);

            if (id != expensiveDTO.Id)
            {
                NotificarError("Id", "O ID informado não confere com o ID da categoria da despesa.");
                return CustomResponse();
            }

            await _expensiveService.Update(expensiveDTO);
            return CustomResponse("Categoria de despesas atualizada com sucesso!");
        }

        /// <summary>
        /// Excluir categoria de despesa
        /// </summary>
        /// <param name="id">Parâmetro para filtro da categoria a ser exclu´´ida</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var expensive = await _expensiveService.GetById(id);

            if (expensive == null)
            {
                NotificarError("Categoria de Despesa", "A Categoria de despesa informada não existe.");
                return CustomResponse();
            }

            await _expensiveService.DeleteLogically(expensive);
            return CustomResponse("Categoria de despesa excluida com sucesso!");
        }

        /*
        /// <summary>
        /// Retornar registros paginados
        /// </summary>
        /// <param name="numPagina">Número da pagina corrente</param>
        /// <param name="qtdPorPagina">Quantidade por página</param>
        /// <param name="orderByFilter">Filtro para ordenação</param>
        /// <param name="TipoOrderBy">Tipo de ordenação</param>
        /// <returns></returns>
        [HttpGet]
        [Route("paginatedResult/{numPagina}/{qtdPorPagina}")]
        [ProducesResponseType(typeof(PaginationVM<ExpensiveVM>), StatusCodes.Status200OK)]
        public async Task<ActionResult<PaginationVM<ExpensiveVM>>> ListarPaginado(int numPagina, int qtdPorPagina, ExpensiveOrderBy? orderByFilter, TypeOrderBy TipoOrderBy = TypeOrderBy.Ascending)
        {
            Expression<Func<Expensive, object>> orderBy = null;

            switch (orderByFilter)
            {
                case ExpensiveOrderBy.Category:
                    orderBy = x => x.Category;
                    break;
                default:
                    break;
            }

            var resultadoPaginado = _expensiveService.GetPaginated<ExpensiveVM>(numPagina, qtdPorPagina, orderBy: orderBy, tipoOrderBy: TipoOrderBy);
            return CustomResponse(resultadoPaginado);
        }
        */
    }
}