using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutrivida.Domain.Contracts.Managers;
using Nutrivida.Domain.Contracts.Repositories;
using Nutrivida.Domain.DTOs;
using Nutrivida.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nutrivida.API.Controllers
{
    [Authorize]
    [Route("api/salecategories")]
    [ApiController]
    public class SaleCategoriesController : APIController
    {
        private readonly ISaleCategoryRepository _SaleCategoryRepository;
        private readonly IMapper _mapper;

        public SaleCategoriesController(ISaleCategoryRepository SaleCategoryRepository, IMapper mapper, INotificationManager _gerenciadorNotificacoes) : base(_gerenciadorNotificacoes)
        {
            _mapper = mapper;
            _SaleCategoryRepository = SaleCategoryRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SaleCategoryDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var salesCategories = await _SaleCategoryRepository.GetAll();
            //mapper
            var salesCategoriesDtos = _mapper.Map<IEnumerable<SaleCategoryDto>>(salesCategories);
            return CustomResponse(salesCategoriesDtos);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(SaleCategoryDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var saleCategory = await _SaleCategoryRepository.GetById(id);

            if (saleCategory == null)
            {
                NotificarError("Categoria de Venda", "A Categoria de Venda informada não existe.");
                return CustomResponse();
            }

            var saleDto = _mapper.Map<SaleCategoryDto>(saleCategory);
            return CustomResponse(saleDto);
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Create(SaleCategoryDto saleCategoryDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            // mapper
            var saleCategory = _mapper.Map<SaleCategoryDto, SaleCategory>(saleCategoryDto);

            _SaleCategoryRepository.Add(saleCategory);
            _SaleCategoryRepository.SaveChanges();
            return CustomResponse("Categoria de vendas cadastrada com sucesso!");
        }


        [HttpPut]
        [Route("update/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(int id, SaleCategoryDto saleCategoryDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var saleCategory = await _SaleCategoryRepository.GetById(id);

            if (saleCategory == null)
            {
                NotificarError("Categoria de Venda", "A Categoria de Venda informada não existe.");
                return CustomResponse();
            }

            // mapper
            _mapper.Map(saleCategoryDto, saleCategory);

            //_SaleCategoryRepository.Update(userBanco);
            await _SaleCategoryRepository.SaveChanges();
            return CustomResponse("Categoria de vendas atualizada com sucesso!");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var saleCategory = await _SaleCategoryRepository.GetById(id);

            if (saleCategory == null)
            {
                NotificarError("Categoria de Venda", "A Categoria de Venda informada não existe.");
                return CustomResponse();
            }

            //_SaleCategoryRepository.Remove(saleCategy);
            await _SaleCategoryRepository.SaveChanges();

            return CustomResponse("Categoria de vendas excluida com sucesso!");
        }

    }
}