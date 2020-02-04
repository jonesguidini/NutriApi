using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nutrivida.Domain.Contracts.Repositories;
using Nutrivida.Domain.DTOs;
using Nutrivida.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nutrivida.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SaleCategoriesController : ControllerBase
    {
        private readonly ISaleCategoryRepository _SaleCategoryRepository;
        private readonly IMapper _mapper;

        public SaleCategoriesController(ISaleCategoryRepository SaleCategoryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _SaleCategoryRepository = SaleCategoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var salesCategories = await _SaleCategoryRepository.GetAll();
            //mapper
            var salesCategoriesDtos = _mapper.Map<IEnumerable<SaleCategoryDto>>(salesCategories);
            return Ok(salesCategoriesDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Sale = await _SaleCategoryRepository.GetById(id);
            var saleDto = _mapper.Map<SaleCategoryDto>(Sale);
            return Ok(saleDto);
        }

        [HttpPost]
        public IActionResult Save(SaleCategoryDto saleCategoryDto)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            // mapper
            var saleCategory = _mapper.Map<SaleCategoryDto, SaleCategory>(saleCategoryDto);

            _SaleCategoryRepository.Add(saleCategory);
            _SaleCategoryRepository.SaveChanges();
            return Ok("Categoria de vendas cadastrada com sucesso!");
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SaleCategoryDto saleCategoryDto)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var userBanco = await _SaleCategoryRepository.GetById(id);

            if(userBanco == null)
                return BadRequest();

            // mapper
            _mapper.Map(saleCategoryDto, userBanco);

            //_SaleCategoryRepository.Update(userBanco);
            _SaleCategoryRepository.SaveChanges();
            return Ok("Categoria de vendas atualizada com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var saleCategy = await _SaleCategoryRepository.GetById(id);

            //_SaleCategoryRepository.Remove(saleCategy);
            _SaleCategoryRepository.SaveChanges();

            return Ok("Categoria de vendas excluida com sucesso!");
        }

    }
}