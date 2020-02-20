using System;
using System.Collections.Generic;
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
    [Route("api/salecategories")]
    [ApiController]
    public class SaleCategoriesController : APIController
    {
        private readonly ISaleCategoryService _SaleCategoryService;
        private readonly IMapper _mapper;
        public SaleCategoriesController(ISaleCategoryService SaleCategoryService, IMapper mapper, INotificationManager _gerenciadorNotificacoes) : base(_gerenciadorNotificacoes)
        {
            _mapper = mapper;
            _SaleCategoryService = SaleCategoryService;
        }

        /// <summary>
        /// Retornar todas categorias de despesas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SaleCategoryVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var SaleCategories = await _SaleCategoryService.GetAll();
            var listSaleCategoryVM = _mapper.Map<IEnumerable<SaleCategoryVM>>(SaleCategories);
            return CustomResponse(listSaleCategoryVM);
        }

        /// <summary>
        /// Retornar categoria de despesa filtrado pelo parametro 'id'
        /// </summary>
        /// <param name="id">Parâmetro para filtro por ID </param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(SaleCategoryVM), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var SaleCategory = await _SaleCategoryService.GetById(id);

            SaleCategoryVM SaleCategoryVM = _mapper.Map<SaleCategoryVM>(SaleCategory);
            return CustomResponse(SaleCategoryVM);
        }

        /// <summary>
        /// Criar nova categoria de despesa
        /// </summary>
        /// <param name="SaleCategoryDTO">Objeto informado para cadastro do registro</param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(SaleCategoryDTO SaleCategoryDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _SaleCategoryService.Add(SaleCategoryDTO);
            return CustomResponse("Categoria de despesa cadastrada com sucesso");
        }

        /// <summary>
        /// Atualizar categoria de despesa
        /// </summary>
        /// <param name="id">Parâmetro para filtro da categoria a ser alterada</param>
        /// <param name="SaleCategoryDTO">Objeto da categoria a ser alterada </param>
        /// <returns></returns>
        [HttpPut]
        [Route("update/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(int id, SaleCategoryDTO SaleCategoryDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var SaleCategoryBanco = await _SaleCategoryService.GetById(id);

            if (id != SaleCategoryDTO.Id)
            {
                NotificarError("Id", "O ID informado não confere com o ID da categoria da despesa.");
                return CustomResponse();
            }

            await _SaleCategoryService.Update(SaleCategoryDTO);
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
            var SaleCategory = await _SaleCategoryService.GetById(id);

            if (SaleCategory == null)
            {
                NotificarError("Categoria de Despesa", "A Categoria de despesa informada não existe.");
                return CustomResponse();
            }

            await _SaleCategoryService.DeleteLogically(SaleCategory);

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
        [ProducesResponseType(typeof(PaginationVM<SaleCategoryVM>), StatusCodes.Status200OK)]
        public async Task<ActionResult<PaginationVM<SaleCategoryVM>>> ListarPaginado(int numPagina, int qtdPorPagina, SaleCategoryOrderBy? orderByFilter, TypeOrderBy TipoOrderBy = TypeOrderBy.Ascending)
        {
            Expression<Func<SaleCategory, object>> orderBy = null;

            switch (orderByFilter)
            {
                case SaleCategoryOrderBy.Category:
                    orderBy = x => x.Category;
                    break;
                default:
                    break;
            }

            var resultadoPaginado = _SaleCategoryService.GetPaginated<SaleCategoryVM>(numPagina, qtdPorPagina, orderBy: orderBy, tipoOrderBy: TipoOrderBy);
            return CustomResponse(resultadoPaginado);
        }
    }
}