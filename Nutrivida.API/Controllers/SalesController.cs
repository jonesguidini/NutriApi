using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutrivida.Domain.Contracts.Managers;
using Nutrivida.Domain.Contracts.Services;
using Nutrivida.Domain.DTOs;
using Nutrivida.Domain.VMs;

namespace Nutrivida.API.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/sales")]
    [ApiController]
    public class SalesController : APIController
    {
        private readonly ISaleService _saleService;
        private readonly IMapper _mapper;
        public SalesController(ISaleService saleService, IMapper mapper, INotificationManager _gerenciadorNotificacoes) : base(_gerenciadorNotificacoes)
        {
            _mapper = mapper;
            _saleService = saleService;
        }

        /// <summary>
        /// Retornar todas categorias de despesas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SaleVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            List<string> includes = new List<string> { "SaleCategory" };

            var saleCategories = await _saleService.GetAll(includes);
            var listSaleVM = _mapper.Map<IEnumerable<SaleVM>>(saleCategories);
            return CustomResponse(listSaleVM);
        }

        /// <summary>
        /// Retornar categoria de despesa filtrado pelo parametro 'id'
        /// </summary>
        /// <param name="id">Parâmetro para filtro por ID </param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(SaleVM), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            List<string> includes = new List<string> { "SaleCategory" };
            var saleCategory = await _saleService.GetById(id, includes);

            SaleVM saleCategoryVM = _mapper.Map<SaleVM>(saleCategory);
            return CustomResponse(saleCategoryVM);
        }

        /// <summary>
        /// Criar nova categoria de despesa
        /// </summary>
        /// <param name="saleDTO">Objeto informado para cadastro do registro</param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(SaleDTO saleDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _saleService.Add(saleDTO);
            return CustomResponse("Categoria de despesa cadastrada com sucesso");
        }

        /// <summary>
        /// Atualizar categoria de despesa
        /// </summary>
        /// <param name="id">Parâmetro para filtro da categoria a ser alterada</param>
        /// <param name="saleDTO">Objeto da categoria a ser alterada </param>
        /// <returns></returns>
        [HttpPut]
        [Route("update/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(int id, SaleDTO saleDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var saleCategoryBanco = await _saleService.GetById(id);

            if (id != saleDTO.Id)
            {
                NotificarError("Id", "O ID informado não confere com o ID da categoria da despesa.");
                return CustomResponse();
            }

            await _saleService.Update(saleDTO);
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
            var sale = await _saleService.GetById(id);

            if (sale == null)
            {
                NotificarError("Categoria de Despesa", "A Categoria de despesa informada não existe.");
                return CustomResponse();
            }

            await _saleService.DeleteLogically(sale);

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
        [ProducesResponseType(typeof(PaginationVM<SaleVM>), StatusCodes.Status200OK)]
        public async Task<ActionResult<PaginationVM<SaleVM>>> ListarPaginado(int numPagina, int qtdPorPagina, SaleOrderBy? orderByFilter, TypeOrderBy TipoOrderBy = TypeOrderBy.Ascending)
        {
            Expression<Func<Sale, object>> orderBy = null;

            switch (orderByFilter)
            {
                case SaleOrderBy.Category:
                    orderBy = x => x.Category;
                    break;
                default:
                    break;
            }

            var resultadoPaginado = _saleService.GetPaginated<SaleVM>(numPagina, qtdPorPagina, orderBy: orderBy, tipoOrderBy: TipoOrderBy);
            return CustomResponse(resultadoPaginado);
        }
        */
    }
}