using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
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
    //[Authorize]
    [Route("api/expensivecategories")]
    [ApiController]
    public class ExpensiveCategoriesController : APIController
    {
        private readonly IExpensiveCategoryService _expensiveCategoryService;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        public ExpensiveCategoriesController(
            IExpensiveCategoryService expensiveCategoryService,
            IAuthService authService,
            IMapper mapper, 
            INotificationManager _gerenciadorNotificacoes) : base(_gerenciadorNotificacoes)
        {
            _mapper = mapper;
            _expensiveCategoryService = expensiveCategoryService;
            _authService = authService;
        }

        /// <summary>
        /// Retornar todas categorias de despesas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ExpensiveCategoryVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            // código de exemplo para trazer registros excluidos em vez de registros ativos
            //List<string> includes = new List<string> { "DeletedByUser" };
            //var expensiveCategories = await _expensiveCategoryService.GetAll(includes, true);

            var expensiveCategories = await _expensiveCategoryService.GetAll();
            var listExpensiveCategoryVM = _mapper.Map<IEnumerable<ExpensiveCategoryVM>>(expensiveCategories);
            return CustomResponse(listExpensiveCategoryVM);
        }

        /// <summary>
        /// Retornar categoria de despesa filtrado pelo parametro 'id'
        /// </summary>
        /// <param name="id">Parâmetro para filtro por ID </param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ExpensiveCategoryVM), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var expensiveCategory = await _expensiveCategoryService.GetById(id);

            ExpensiveCategoryVM expensiveCategoryVM = _mapper.Map<ExpensiveCategoryVM>(expensiveCategory);
            return CustomResponse(expensiveCategoryVM);
        }

        /// <summary>
        /// Criar nova categoria de despesa
        /// </summary>
        /// <param name="expensiveCategoryDTO">Objeto informado para cadastro do registro</param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(ExpensiveCategoryDTO expensiveCategoryDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _expensiveCategoryService.Add(expensiveCategoryDTO);
            return CustomResponse("Categoria de despesa cadastrada com sucesso");
        }

        /// <summary>
        /// Atualizar categoria de despesa
        /// </summary>
        /// <param name="id">Parâmetro para filtro da categoria a ser alterada</param>
        /// <param name="expensiveCategoryDTO">Objeto da categoria a ser alterada </param>
        /// <returns></returns>
        [HttpPut]
        [Route("update/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(int id, ExpensiveCategoryDTO expensiveCategoryDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var expensiveCategoryBanco = await _expensiveCategoryService.GetById(id);

            if (id != expensiveCategoryDTO.Id)
            {
                NotificarError("Id", "O ID informado não confere com o ID da categoria da despesa.");
                return CustomResponse();
            }

            await _expensiveCategoryService.Update(expensiveCategoryDTO);
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
            var expensiveCategory = await _expensiveCategoryService.GetById(id);

            if (expensiveCategory == null)
            {
                NotificarError("Categoria de Despesa", "A Categoria de despesa informada não existe.");
                return CustomResponse();
            }

            // configura a exclusão lógica
            var userId = Convert.ToInt32(_authService.GetClaims("UserId"));
            expensiveCategory.IsDeleted = true;
            expensiveCategory.DeletedByUserId = userId;
            expensiveCategory.DateDeleted = DateTime.Now;

            await _expensiveCategoryService.Update(expensiveCategory);
            return CustomResponse("Categoria de despesa excluida com sucesso!");
        }

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
        [ProducesResponseType(typeof(PaginationVM<ExpensiveCategoryVM>), StatusCodes.Status200OK)]
        public async Task<ActionResult<PaginationVM<ExpensiveCategoryVM>>> ListarPaginado(int numPagina, int qtdPorPagina, ExpensiveCategoryOrderBy? orderByFilter, TypeOrderBy TipoOrderBy = TypeOrderBy.Ascending)
        {
            Expression<Func<ExpensiveCategory, object>> orderBy = null;

            switch (orderByFilter)
            {
                case ExpensiveCategoryOrderBy.Category:
                    orderBy = x => x.Category;
                    break;
                default:
                    break;
            }

            var resultadoPaginado = _expensiveCategoryService.GetPaginated<ExpensiveCategoryVM>(numPagina, qtdPorPagina, orderBy: orderBy, tipoOrderBy: TipoOrderBy);
            return CustomResponse(resultadoPaginado);
        }
    }
}